using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEnemigos : MonoBehaviour
{
    public float tiempoDeVida = 2.0f; // Tiempo en segundos antes de la destrucci�n.

    private bool haCambiadoDeColor = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� en el trigger tiene el tag "misil".
        if (other.CompareTag("misil") && !haCambiadoDeColor)
        {
            haCambiadoDeColor = true;

            // Cambia el color del objeto a rojo.
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }

            // Inicia el temporizador antes de la destrucci�n.
            Invoke("DestruirObjeto", tiempoDeVida);
        }
    }

    private void DestruirObjeto()
    {
        // Destruye el objeto despu�s de tiempoDeVida segundos.
        Destroy(gameObject);
    }
}