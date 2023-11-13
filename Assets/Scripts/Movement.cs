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
        // Encuentra la c�mara de la VR (aseg�rate de que la c�mara de la VR est� etiquetada como "MainCamera")
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
     

        // Mueve el objeto seg�n la direcci�n de movimiento
        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime, Space.World);
    }

    // M�todo para activar/desactivar el movimiento hacia adelante
    public void ActivarDesactivarAvance()
    {
        avanzando = !avanzando;

        if (!avanzando)
        {
            // Detener el movimiento cuando se desactiva el avance
            // Puedes agregar aqu� cualquier otra l�gica de detenci�n que necesites
        }

        // Si se activa avanzando, aseg�rate de desactivar retrocediendo
        if (avanzando)
        {
            retrocediendo = false;
        }
    }

    // M�todo para activar/desactivar el movimiento de retroceso
    public void ActivarDesactivarRetroceso()
    {
        retrocediendo = !retrocediendo;

        if (!retrocediendo)
        {
            // Detener el movimiento cuando se desactiva retrocediendo
            // Puedes agregar aqu� cualquier otra l�gica de detenci�n que necesites
        }

        // Si se activa retrocediendo, aseg�rate de desactivar avanzando
        if (retrocediendo)
        {
            avanzando = false;
        }
    }


  




    // M�todo para obtener la direcci�n hacia la que mira la c�mara de la VR desde su rotaci�n
    private Vector3 ObtenerDireccionCamara()
    {
        Quaternion rotacionCamara = camaraVR.rotation;
        Vector3 direccionJugador = rotacionCamara * Vector3.forward;
        direccionJugador.y = 0;
        return direccionJugador.normalized;
    }
}
