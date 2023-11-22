using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDron : MonoBehaviour
{
    public float tiempoDeVida = 3.0f; // Tiempo en segundos antes de la destrucci�n.
    private bool haCambiadoDeColor = false;
    public float tiempoCambioColor = 1.0f; // Tiempo en segundos para que el renderer cambie de color 
    private bool haCambiadoDeColorBlanco = false;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� en el trigger tiene el tag "misil".
        if (other.CompareTag("bullet") && !haCambiadoDeColor)
        {
            Debug.Log("entre a el if de bullet");
            haCambiadoDeColor = true;

            // Cambia el color del objeto a rojo.
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
            // Inicia el temporizador antes de la destrucci�n.
            Debug.Log("Destrui misil");
            Invoke("DestruirObjeto", tiempoDeVida);
        }
    }

    private void DestruirObjeto()
    {
        // Destruye el objeto despu�s de tiempoDeVida segundos.
        Destroy(gameObject);
    }
}