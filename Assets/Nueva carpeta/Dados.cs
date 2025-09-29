using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dados : MonoBehaviour
{
    public Sprite[] carasdelosdados;
    [SerializeField] private Image[] dadosUI;
    public AudioSource sonido;
    public float suspenso = 0.5f;

    public int[] resultados { get; private set; }

    public void TirarDado()
    {
        if (sonido) sonido.Play();
        resultados = new int[dadosUI.Length];
        for (int i = 0; i < dadosUI.Length; i++)
            resultados[i] = Random.Range(1, 7);
        StartCoroutine(MostrarCaras());
    }

    private IEnumerator MostrarCaras()
    {
        yield return new WaitForSeconds(suspenso);
        for (int i = 0; i < dadosUI.Length; i++)
            if (dadosUI[i]) dadosUI[i].sprite = carasdelosdados[resultados[i] - 1];
    }
}
