using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class BulletLogic : MonoBehaviour
{
    public string enemyTag = "enemy";
    public VisualEffect visualEffect;
    public LayerMask groundLayer;
    private AudioSource ExplodeAudio; // Agrega una referencia al AudioSource
    public AudioClip ExplodeSound; //

    // No necesitas el método Start para configurar el AudioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag) || (groundLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            if (visualEffect != null)
            {
                visualEffect.Play();
            }

            // Configura el AudioSource y reproduce el sonido
            if (ExplodeAudio == null)
            {
                ExplodeAudio = gameObject.AddComponent<AudioSource>();
                ExplodeAudio.clip = ExplodeSound;
                ExplodeAudio.volume = 0.3f;
            }

            ExplodeAudio.Play();

            Destroy(gameObject, 0.9f);
            // Puedes agregar aquí cualquier otra lógica que desees cuando el misil colisiona con un enemigo o el suelo.
        }
    }
}
