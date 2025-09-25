using UnityEngine;
using TMPro;
using System.Collections;

public class Eljugador : MonoBehaviour
{
    [SerializeField] TMP_Text plataText;
    [SerializeField] TMP_Text apuestaText;
    [SerializeField] TMP_Text numeroText;
    [SerializeField] TMP_Text mensajeFinalText;

    [SerializeField] int dinero = 5000;
    int apuesta = 0;
    int numeroElegido = 1;

    [SerializeField] int pasoApuesta = 100;
    [SerializeField] int apuestaMin = 0;
    [SerializeField] int minNumero = 1;
    [SerializeField] int maxNumero = 6;

    [SerializeField] Dados dados;



    void Start()
    {
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (plataText) plataText.text = $"$ {dinero:n0}";
        if (apuestaText) apuestaText.text = $"Apuesta: $ {apuesta:n0}";
        if (numeroText) numeroText.text = $"Número: {numeroElegido}";
    }

    public void SubirApuesta()
    {
        int maxApuesta = dinero; 
        apuesta = Mathf.Clamp(apuesta + pasoApuesta, apuestaMin, maxApuesta);
        ActualizarUI();
    }

    public void BajarApuesta()
    {
        int maxApuesta = dinero;
        apuesta = Mathf.Clamp(apuesta - pasoApuesta, apuestaMin, maxApuesta);
        ActualizarUI();
    }

    public void SubirNumero()
    {
        numeroElegido = Mathf.Clamp(numeroElegido + 1, minNumero, maxNumero);
        ActualizarUI();
    }

    public void BajarNumero()
    {
        numeroElegido = Mathf.Clamp(numeroElegido - 1, minNumero, maxNumero);
        ActualizarUI();
    }


    public void Confirmar()
    {
        // Validaciones básicas
        if (apuesta <= 0)
        {
            if (mensajeFinalText) mensajeFinalText.text = "Apuesta debe ser > 0";
            return;
        }
        if (apuesta > dinero)
        {
            if (mensajeFinalText) mensajeFinalText.text = "No tienes suficiente dinero";
            return;
        }

        dados.TirarDado();

        StartCoroutine(JuzgarTrasSuspenso());
    }

    System.Collections.IEnumerator JuzgarTrasSuspenso()
    {
        yield return new WaitForSeconds(dados.suspenso + 0.05f);

        int resultado = dados.resultado;

        if (resultado == numeroElegido)
        {
            dinero += apuesta; 
            if (mensajeFinalText) mensajeFinalText.text = $" Vamooooooos ¡Ganaste! Salió {resultado}";
        }
        else
        {
            dinero -= apuesta; 
            if (mensajeFinalText) mensajeFinalText.text = $" Que mal, Perdiste. Salió {resultado}";
        }

        apuesta = Mathf.Clamp(apuesta, apuestaMin, dinero);

        ActualizarUI();


    }
    


}


