using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.Events;


public class ElJugador : MonoBehaviour
{
    public UnityEvent GameOver;

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
        if (mensajeFinalText) mensajeFinalText.text = "";
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

    IEnumerator JuzgarTrasSuspenso()
    {
        yield return new WaitForSeconds(dados.suspenso + 0.05f);
        var arr = dados.resultados;
        bool acierta = Array.Exists(arr, r => r == numeroElegido);

        if (acierta)
        {
            dinero += apuesta;
            if (mensajeFinalText) mensajeFinalText.text = $"🎉 Ganaste. Salió {numeroElegido}";
        }
        else
        {
            dinero -= apuesta;
            if (mensajeFinalText) mensajeFinalText.text = $"❌ Perdiste. Salió {arr[0]}";
        }
        
        if (dinero <= 0)
        {
            GameOver.Invoke();
        }
    

        apuesta = Mathf.Clamp(apuesta, apuestaMin, dinero);
        ActualizarUI();
    }


}
