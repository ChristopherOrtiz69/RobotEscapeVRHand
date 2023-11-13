using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
public class LogicaBullet : MonoBehaviour
{
    public float tiempoDeVida = 3.0f; // Tiempo en segundos antes de la destrucción.
    private bool haCambiadoDeColor = false;
    public float tiempoCambioColor = 1.0f; // Tiempo en segundos para que el renderer cambie de color 
    private bool haCambiadoDeColorBlanco = false;
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el trigger tiene el tag "misil".
        if (other.CompareTag("bullet") && !haCambiadoDeColor)
        {
            haCambiadoDeColor = true;

            // Cambia el color del objeto a rojo.
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
            // Inicia el temporizador antes de la destrucción.
            Invoke("DestruirObjeto", tiempoDeVida);
        }
    }

    private void DestruirObjeto()
    {
        // Destruye el objeto después de tiempoDeVida segundos.
        Destroy(gameObject);
    }
}