using UnityEngine;
using UnityEngine.Events;

public class Panelsecreto : MonoBehaviour
{
    public UnityEvent PanelAbierto;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PanelAbierto.Invoke();
        }
    }
}
