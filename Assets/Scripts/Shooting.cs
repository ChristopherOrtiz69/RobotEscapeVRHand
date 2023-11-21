using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform weaponOrigin;
    public Camera playerCamera;
    public float shotForce = 10f;
    public float maxShotCooldown = 2f;
    private Movement movement;
    public LayerMask collisionLayer;
    private AudioSource shootingAudio; // Agrega una referencia al AudioSource
    public AudioClip shootingSound; //



    private float shotTimer;
    void Start()
    {
        shootingAudio = gameObject.AddComponent<AudioSource>();
        shootingAudio.clip = shootingSound;
        shootingAudio.volume = 0.05f;
    }

    private void Update()
    {
        shotTimer += Time.deltaTime;

      
    }

    public void Shoot()
    {
        Vector3 weaponOriginPosition = weaponOrigin.position;
        Vector3 shotDirection = playerCamera.transform.forward;

        GameObject projectile = Instantiate(projectilePrefab, weaponOriginPosition, Quaternion.identity);

        // Calcula la rotación para hacer que el proyectil apunte en la dirección correcta.
        Quaternion rotation = Quaternion.LookRotation(shotDirection);

        // Aplica la rotación al proyectil.
        projectile.transform.rotation = rotation;
        AudioSource audioSource = projectile.AddComponent<AudioSource>();
        if (shootingAudio != null)
        {
            shootingAudio.Play();
        }


        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shotDirection * shotForce, ForceMode.Impulse);
        }

        // Invoca una función que destruirá el objeto disparado después de 5 segundos.
        StartCoroutine(DestroyProjectileAfterDelay(projectile, 5f));
    }

    private IEnumerator DestroyProjectileAfterDelay(GameObject projectile, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(projectile);
    }


    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (other.CompareTag("enemy"))
        {        
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Desactiva el mesh del proyectil después de medio segundo.
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                StartCoroutine(DeactivateMesh(meshRenderer, 0.2f));
            }
            Destroy(gameObject, 0.5f);
        }

        if (other.gameObject.layer == collisionLayer)
        {
            // Desactiva el mesh del proyectil después de medio segundo.
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                StartCoroutine(DeactivateMesh(meshRenderer, 0.2f));
            }
            Destroy(gameObject, 0.5f);
        }
    }
    private IEnumerator DeactivateMesh(MeshRenderer meshRenderer, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (meshRenderer != null)
        {
            meshRenderer.enabled = false;
        }
    }

}





    
