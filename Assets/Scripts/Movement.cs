using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad de movimiento
    public  bool avanzando = false;
    public bool retrocediendo = false;
    private Transform camaraVR;

    void Start()
    {
        // Encuentra la cámara de la VR (asegúrate de que la cámara de la VR esté etiquetada como "MainCamera")
        camaraVR = Camera.main.transform;
    }

    void Update()
    {
        Vector3 direccionMovimiento = Vector3.zero;

        if (avanzando)
        {
            direccionMovimiento = ObtenerDireccionCamara();
        }
        else if (retrocediendo)
        {
            direccionMovimiento = -ObtenerDireccionCamara();
        }
     

        // Mueve el objeto según la dirección de movimiento
        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime, Space.World);
    }

    // Método para activar/desactivar el movimiento hacia adelante
    public void ActivarDesactivarAvance()
    {
        avanzando = !avanzando;

        if (!avanzando)
        {
            // Detener el movimiento cuando se desactiva el avance
            // Puedes agregar aquí cualquier otra lógica de detención que necesites
        }

        // Si se activa avanzando, asegúrate de desactivar retrocediendo
        if (avanzando)
        {
            retrocediendo = false;
        }
    }

    // Método para activar/desactivar el movimiento de retroceso
    public void ActivarDesactivarRetroceso()
    {
        retrocediendo = !retrocediendo;

        if (!retrocediendo)
        {
            // Detener el movimiento cuando se desactiva retrocediendo
            // Puedes agregar aquí cualquier otra lógica de detención que necesites
        }

        // Si se activa retrocediendo, asegúrate de desactivar avanzando
        if (retrocediendo)
        {
            avanzando = false;
        }
    }


  




    // Método para obtener la dirección hacia la que mira la cámara de la VR desde su rotación
    private Vector3 ObtenerDireccionCamara()
    {
        Quaternion rotacionCamara = camaraVR.rotation;
        Vector3 direccionJugador = rotacionCamara * Vector3.forward;
        direccionJugador.y = 0;
        return direccionJugador.normalized;
    }
}
