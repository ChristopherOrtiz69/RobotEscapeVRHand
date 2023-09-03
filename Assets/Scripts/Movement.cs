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
        // Encuentra la cámara de la VR (asegúrate de que la cámara de la VR esté etiquetada como "MainCamera")
        camaraVR = Camera.main.transform;
    }

    void Update()
    {
        if (activado)
        {
            // Aqui obtiene la rotación de la cámara de la VR
            Quaternion rotacionCamara = camaraVR.rotation;

            // Aqui obtiene la dirección hacia la que mira la cámara de la VR desde su rotación
            Vector3 direccionJugador = rotacionCamara * Vector3.forward;

            // Asegurarse de que la dirección no tenga componente Y
            direccionJugador.y = 0;

            // Normalizar la dirección y mover el objeto
            transform.Translate(direccionJugador.normalized * velocidad * Time.deltaTime, Space.World);
        }
    }

    // Método para activar/desactivar el objeto
    public void ActivarDesactivar()
    {
        activado = !activado;

        if (!activado)
        {
            // Detener el movimiento cuando se desactiva
            // Puedes agregar aquí cualquier otra lógica de detención que necesites
        }
    }
}