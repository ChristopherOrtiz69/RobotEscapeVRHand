using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena
using UnityEngine.UI;
using TMPro;
public class MenuInicio : MonoBehaviour
{
    public GameObject panelCreditos;
    public GameObject panelAocultar;

    // Esta función se activará cuando presiones el botón "Play"
    public void Play()
    {
        // Cambia "NombreDeTuEscena" al nombre real de la escena que quieres cargar
        UnityEngine.SceneManagement.SceneManager.LoadScene("1level");
    }

    // Esta función se activará cuando presiones el botón "ActivarPanelCreditos"
    public void ActivarPanelCreditos()
    {
        if (panelCreditos != null)
        {
            panelCreditos.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el panel de créditos en el Inspector.");
        }
    }

    // Esta función se activará cuando presiones el botón para ocultar un panel
    public void OcultarPanel()
    {
        if (panelAocultar != null)
        {
            panelAocultar.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el panel a ocultar en el Inspector.");
        }
    }
}