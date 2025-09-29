using UnityEngine;
using TMPro;

public class PlataJugador : MonoBehaviour
{
    [SerializeField] ElJugador jugador;       // referencia al script del jugador
    [SerializeField] TMP_Text dineroText;     // opcional: para mostrar dinero aquí también

    public void AgregarDinero(int cantidad)
    {
        jugador.AgregarDinero(cantidad);
        ActualizarUI();
    }

    public void QuitarDinero(int cantidad)
    {
        jugador.AgregarDinero(-cantidad);
        ActualizarUI();
    }

    void ActualizarUI()
    {
        if (dineroText) dineroText.text = $"$ {jugador.DineroActual:n0}";
    }
}
