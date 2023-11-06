using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform weaponOrigin;
    public Camera playerCamera;
    public float shotForce = 10f;
    public float shotCooldown = 1f;
    private Movement movement;
    public LayerMask collisionLayer;

    private float shotTimer;

    private void Update()
    {
        shotTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && shotTimer >= shotCooldown)
        {
            Shoot();
            shotTimer = 0f;
        }
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

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shotDirection * shotForce, ForceMode.Impulse);
        }
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (other.CompareTag("enemy"))
        {
            Debug.Log("Colisión con objeto con el tag 'enemy'");
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            // Desactiva el mesh del proyectil después de medio segundo.
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                StartCoroutine(DeactivateMesh(meshRenderer, 0.2f));
            }

            // Destruye el objeto después de medio segundo.
            Destroy(gameObject, 0.5f);
        }

        if (other.gameObject.layer == collisionLayer)
        {
            Debug.Log("Detecté colisión en la capa");

            // Desactiva el mesh del proyectil después de medio segundo.
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                StartCoroutine(DeactivateMesh(meshRenderer, 0.2f));
            }

            // Destruye el objeto después de medio segundo.
            Destroy(gameObject, 0.8f);
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

public void MisilRelentizado()
    {

        if (movement == true)
        {
            Debug.Log("Disparo esta en 1");
            shotForce = 1f;
        }
        if (movement == false)
        {
            Debug.Log("Disparo esta en 10");
            shotForce = 80f;
        }
    }
}





    
