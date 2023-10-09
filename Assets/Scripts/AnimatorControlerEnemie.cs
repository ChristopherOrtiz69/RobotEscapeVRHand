using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControlerEnemie : MonoBehaviour
{
    // Lista de objetos con Animator que activar�n la animaci�n cuando colisionen.
    public List<Animator> animatorsObjetosAnimados = new List<Animator>();

    // Nombre del trigger que activar� la animaci�n.
    public string triggerAnimacion = "TriggerAnimacion";

    private void OnTriggerEnter(Collider other)
    {
        // Comprueba si el objeto colisionado tiene una etiqueta espec�fica (opcional).
        if (other.CompareTag("enemy"))
        {
            // Itera a trav�s de la lista de animators y activa el trigger en cada uno de ellos.
            foreach (Animator animator in animatorsObjetosAnimados)
            {
                animator.SetTrigger(triggerAnimacion);
            }
        }
    }
}       