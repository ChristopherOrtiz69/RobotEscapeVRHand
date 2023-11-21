using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float velocidad = 5.0f;
    public bool avanzando = false;
    public bool retrocediendo = false;
    private Transform camaraVR;
    public AudioClip avanceSound; // Asigna un AudioClip desde el Inspector
    public AudioClip retrocesoSound; // Asigna un AudioClip desde el Inspector

    private AudioSource audioSource;

    void Start()
    {
        camaraVR = Camera.main.transform;
        audioSource = GetComponent<AudioSource>();
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

        transform.Translate(direccionMovimiento * velocidad * Time.deltaTime, Space.World);
    }

    public void ActivarDesactivarAvance()
    {
        
        avanzando = !avanzando;
        if (!avanzando)
        {
            DetenerMovimiento(); 
            DetenerSonido();
        }
        if (avanzando)
        {
            retrocediendo = false;
            ReproducirSonido(avanceSound);
        }
    }


    public void ActivarDesactivarRetroceso()
    {
        retrocediendo = !retrocediendo;

        if (!retrocediendo)
        {
            DetenerMovimiento(); // Puedes personalizar esta función para detener el movimiento como desees.
            DetenerSonido();
        }
       

        if (retrocediendo)
        {
            avanzando = false;
            ReproducirSonido(retrocesoSound);
        }
    }

    private void DetenerMovimiento()
    {
        // Lógica para detener el movimiento (puedes personalizar según tus necesidades).
    }

    private void ReproducirSonido(AudioClip sound)
    {
        if (audioSource != null && sound != null)
        {
            audioSource.clip = sound;
            audioSource.Play();
        }
    }
    private void DetenerSonido()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    private Vector3 ObtenerDireccionCamara()
    {
        Quaternion rotacionCamara = camaraVR.rotation;
        Vector3 direccionJugador = rotacionCamara * Vector3.forward;
        direccionJugador.y = 0;
        return direccionJugador.normalized;
    }
}
