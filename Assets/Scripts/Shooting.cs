using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Asigna el objeto a disparar desde el Inspector.
    public Transform weaponOrigin; // Asigna el punto de origen del arma desde el Inspector.
    public Camera playerCamera; // Asigna la cámara del jugador desde el Inspector.
    public float shotForce = 10f; // Fuerza del disparo.
    public float shotCooldown = 1f; // Tiempo de espera entre disparos.
    private Movement movement;

    private float shotTimer;

    private void Update()
    {
        
        // Controla el tiempo entre disparos.
        shotTimer += Time.deltaTime;

        // Disparar cuando se presiona un botón físico en la escena.
        if (Input.GetButtonDown("Fire1") && shotTimer >= shotCooldown)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    private void Shoot()
    {
        // Obtiene la posición del arma como el punto de origen.
        Vector3 weaponOriginPosition = weaponOrigin.position;

        // Convierte la posición del arma en un rayo hacia la dirección de la cámara.
        Vector3 shotDirection = playerCamera.transform.forward;
       

        // Crea una instancia del objeto projectilePrefab en el punto de origen del arma.
        GameObject projectile = Instantiate(projectilePrefab, weaponOriginPosition, Quaternion.identity);
       


        // Agrega fuerza al objeto proyectil en la dirección de la cámara.
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shotDirection * shotForce, ForceMode.Impulse);
           
        }

        // Destruye el proyectil después de un tiempo para evitar que llenen la escena.
        Destroy(projectile, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión involucra un objeto con el tag "enemy".
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Destruye el objeto enemigo.
            Destroy(collision.gameObject);
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
