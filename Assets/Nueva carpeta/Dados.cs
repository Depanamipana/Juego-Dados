using UnityEngine;
using UnityEngine.UI; 
using System.Collections; 

public class Dados : MonoBehaviour
{
    public Sprite[] carasdelosdados; 
    public Image dadoUI; 
    public int resultado; 
    public AudioSource sonido; 
    public float suspenso = 0.5f; 

    public void TirarDado()
{
    sonido.Play();
    resultado = Random.Range(1, 7); // número entre 1 y 6
    StartCoroutine(MostrarCara());
}

private IEnumerator MostrarCara()
{
    yield return new WaitForSeconds(suspenso);
    dadoUI.sprite = carasdelosdados[resultado - 1];
}
    
}
