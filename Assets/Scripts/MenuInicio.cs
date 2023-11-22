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

    // Esta funci�n se activar� cuando presiones el bot�n "Play"
    public void Play()
    {
        // Cambia "NombreDeTuEscena" al nombre real de la escena que quieres cargar
        UnityEngine.SceneManagement.SceneManager.LoadScene("1level");
    }

    // Esta funci�n se activar� cuando presiones el bot�n "ActivarPanelCreditos"
    public void ActivarPanelCreditos()
    {
        if (panelCreditos != null)
        {
            panelCreditos.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el panel de cr�ditos en el Inspector.");
        }
    }

    // Esta funci�n se activar� cuando presiones el bot�n para ocultar un panel
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