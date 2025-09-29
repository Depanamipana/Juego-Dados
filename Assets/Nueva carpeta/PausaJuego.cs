using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    [SerializeField] GameObject panelPausa;     // Panel de UI que se muestra en pausa
    [SerializeField] AudioSource musicaFondo;   // Música de fondo
    [SerializeField] Button[] botonesJuego;     // Botones de la jugabilidad (apuesta, confirmar, etc.)

    bool enPausa = false;

    public void ActivarPausa()
    {
        if (enPausa) return;

        enPausa = true;
        Time.timeScale = 0f;

        if (panelPausa) panelPausa.SetActive(true);
        if (musicaFondo) musicaFondo.Pause();

        foreach (var b in botonesJuego)
            if (b) b.interactable = false;
    }

    public void Reanudar()
    {
        if (!enPausa) return;

        enPausa = false;
        Time.timeScale = 1f;

        if (panelPausa) panelPausa.SetActive(false);
        if (musicaFondo) musicaFondo.UnPause();

        foreach (var b in botonesJuego)
            if (b) b.interactable = true;
    }
}
