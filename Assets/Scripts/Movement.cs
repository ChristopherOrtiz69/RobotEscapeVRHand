using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 5.0f; // Velocidad de movimiento
    private bool activado = false;
    private Transform camaraVR;

    void Start()
    {
        // Encuentra la c�mara de la VR (aseg�rate de que la c�mara de la VR est� etiquetada como "MainCamera")
        camaraVR = Camera.main.transform;
    }

    void Update()
    {
        if (activado)
        {
            // Aqui obtiene la rotaci�n de la c�mara de la VR
            Quaternion rotacionCamara = camaraVR.rotation;

            // Aqui obtiene la direcci�n hacia la que mira la c�mara de la VR desde su rotaci�n
            Vector3 direccionJugador = rotacionCamara * Vector3.forward;

            // Asegurarse de que la direcci�n no tenga componente Y
            direccionJugador.y = 0;

            // Normalizar la direcci�n y mover el objeto
            transform.Translate(direccionJugador.normalized * velocidad * Time.deltaTime, Space.World);
        }
    }

    // M�todo para activar/desactivar el objeto
    public void ActivarDesactivar()
    {
        activado = !activado;

        if (!activado)
        {
            // Detener el movimiento cuando se desactiva
            // Puedes agregar aqu� cualquier otra l�gica de detenci�n que necesites
        }
    }
}