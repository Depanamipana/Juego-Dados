using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] Slider soundsSlider;
    [SerializeField] AudioMixer masterMixer;

    void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float value)
    {
        if (value < 1f)
            value = 0.001f;

        RefreshSlider(value);
        PlayerPrefs.SetFloat("SavedMasterVolume", value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value / 100f) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundsSlider.value);
    }

    public void RefreshSlider(float value)
    {
        soundsSlider.value = value;
    }
}
