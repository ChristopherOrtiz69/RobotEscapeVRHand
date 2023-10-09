using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionMisilObjeto : MonoBehaviour
{
    // Referencia al Animator de este objeto.
    private Animator animator;

    // Nombre del trigger que activará la animación.
    public string triggerAnimacion = "misil";

    private void Start()
    {
        // Obtén una referencia al Animator de este objeto.
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto colisionado es el misil.
        if (other.CompareTag("misil"))
        {
            // Activa el trigger en el Animator para iniciar la animación.
            animator.SetTrigger(triggerAnimacion);
        }
    }
}
