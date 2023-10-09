using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BulletLogic : MonoBehaviour
{
    public string enemyTag = "enemy"; // Etiqueta de los objetos enemigos
    public VisualEffect visualEffect; // Asigna el VFXGraph directamente en el inspector
    public LayerMask groundLayer; // Capa para el suelo

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag) || (groundLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            // Verificar si el objeto colisionado tiene la etiqueta "enemy"
            // o está en la capa "WhatIsGround"
            // Si es así, activar el efecto visual
            if (visualEffect != null)
            {
                visualEffect.Play(); // Activar el efecto visual
            }



            // Aquí puedes agregar cualquier otra lógica que desees cuando el misil colisiona con un enemigo o el suelo.
            // Por ejemplo, puedes destruir el objeto enemigo o realizar otros eventos relacionados con el juego.
        }
    }
}