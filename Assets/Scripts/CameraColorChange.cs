using UnityEngine;

public class CameraColorChange : MonoBehaviour
{
    // Referencia al panel que se activará/desactivará
    public GameObject blackoutPanel;

    private void Start()
    {
        // Asegúrate de que el panel esté desactivado al inicio
        if (blackoutPanel != null)
        {
            blackoutPanel.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Activa el panel para oscurecer la vista
            if (blackoutPanel != null)
            {
                blackoutPanel.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Desactiva el panel para restaurar la vista
            if (blackoutPanel != null)
            {
                blackoutPanel.SetActive(false);
            }
        }
    }
}