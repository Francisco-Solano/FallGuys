using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorVidas : MonoBehaviour
{
    public Image[] corazones;
    private int vidas = 3;

    public void InicializarVidas()
    {
        vidas = 3;
        UpdateVidasUI();
    }

    void Start()
    {
        // Aseg�rate de que el tama�o del array coincida con el n�mero de vidas
        if (corazones.Length != vidas)
        {
            Debug.LogError("El tama�o del array de corazones no coincide con el n�mero de vidas.");
            return;
        }

        // Inicializar la representaci�n gr�fica de las vidas
        UpdateVidasUI();
    }

    void UpdateVidasUI()
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            corazones[i].enabled = i < vidas; // Activa o desactiva la imagen del coraz�n seg�n el n�mero de vidas
        }
    }

    public void PerderVida()
    {
        if (vidas > 0)
        {
            vidas--;
            UpdateVidasUI();

            if (vidas == 0)
            {
                // Aqu� deber�as mostrar el mensaje de "Has perdido" y realizar las acciones correspondientes
                Debug.Log("Has perdido todas las vidas");
            }
        }
    }

    public bool TieneVidas()
    {
        return vidas > 0;
    }
}
