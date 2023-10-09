using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControlerEnemie : MonoBehaviour
{
    // Lista de objetos con Animator que activarán la animación cuando colisionen.
    public List<Animator> animatorsObjetosAnimados = new List<Animator>();

    // Nombre del trigger que activará la animación.
    public string triggerAnimacion = "TriggerAnimacion";

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto colisionado tiene una etiqueta específica (opcional).
        if (other.CompareTag("enemy"))
        {
            // Itera a través de la lista de animators y activa el trigger en cada uno de ellos.
            foreach (Animator animator in animatorsObjetosAnimados)
            {
                animator.SetTrigger(triggerAnimacion);
            }
        }
    }
}       