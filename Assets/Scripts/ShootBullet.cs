using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    private bool isShooting = false;
    private Animator animator;
    private AudioSource shootingAudio; // Agrega una referencia al AudioSource
    public AudioClip shootingSound; // Asigna un AudioClip desde el Inspector

    void Start()
    {
        // Obtener las referencias al Animator y AudioSource al inicio
        animator = GetComponent<Animator>();
        shootingAudio = GetComponent<AudioSource>();
        shootingAudio.clip = shootingSound; // Asigna el AudioClip al AudioSource
    }

    // Llamada cuando se presiona el botón en la escena para iniciar el disparo automático
    public void OnStartShootButtonPressed()
    {
        StartShooting();
    }

    public void StartShooting()
    {
        if (!isShooting)
        {
            isShooting = true;

            // Iniciar la animación
            if (animator != null)
            {
                animator.SetBool("Shoot", false);
            }

            // Reproducir el sonido de disparo
            if (shootingAudio != null)
            {
                shootingAudio.Play();
            }

            StartCoroutine(ShootContinuously());
        }
    }

    public void StopShooting()
    {
        if (isShooting)
        {
            isShooting = false;

            // Detener la animación
            if (animator != null)
            {
                animator.SetBool("Shoot", true);
            }

            // Detener el sonido de disparo
            if (shootingAudio != null)
            {
                shootingAudio.Stop();
            }

            StopCoroutine(ShootContinuously());
        }
    }
private IEnumerator ShootContinuously()
    {
        while (isShooting)
        {
            Shoot();
            yield return null; // Espera un frame antes de disparar nuevamente
        }
    }

    public void Shoot()
    {
        // Crear una instancia de la bala en el punto de origen
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Obtener el componente Rigidbody de la bala
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Comprobar si la bala tiene un Rigidbody
        if (bulletRigidbody != null)
        {
            // Obtener la dirección en la que el jugador está mirando (usando la cabeza en VR)
            Vector3 shootDirection = Camera.main.transform.forward;

            // Aplicar fuerza a la bala en la dirección en la que el jugador está mirando
            bulletRigidbody.AddForce(shootDirection * bulletSpeed, ForceMode.VelocityChange);
        }
        else
        {
            Debug.LogWarning("La bala no tiene un Rigidbody adjunto.");
        }

        StartCoroutine(DestroyProjectileAfterDelay(bullet, 1f));
    }


    private IEnumerator DestroyProjectileAfterDelay(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
