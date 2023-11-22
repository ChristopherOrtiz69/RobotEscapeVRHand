using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeEscena = "2level";

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que ha entrado en contacto tiene el tag "target"
        if (collision.gameObject.CompareTag("Target"))
        {
            // Cambia a la escena especificada
            SceneManager.LoadScene(nombreDeEscena);
        }
    }
}
