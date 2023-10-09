using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject projectilePrefab; // Asigna el objeto a disparar desde el Inspector.
    public Transform weaponOrigin; // Asigna el punto de origen del arma desde el Inspector.
    public Camera playerCamera; // Asigna la c�mara del jugador desde el Inspector.
    public float shotForce = 10f; // Fuerza del disparo.
    public float shotCooldown = 1f; // Tiempo de espera entre disparos.
    private Movement movement;
    public LayerMask collisionLayer;

    private float shotTimer;

    private void Update()
    {

        // Controla el tiempo entre disparos.
        shotTimer += Time.deltaTime;

        // Disparar cuando se presiona un bot�n f�sico en la escena.
        if (Input.GetButtonDown("Fire1") && shotTimer >= shotCooldown)
        {
            Shoot();
            shotTimer = 0f;
        }
    }

    private void Shoot()
    {
        // Obtiene la posici�n del arma como el punto de origen.
        Vector3 weaponOriginPosition = weaponOrigin.position;

        // Convierte la posici�n del arma en un rayo hacia la direcci�n de la c�mara.
        Vector3 shotDirection = playerCamera.transform.forward;


        // Crea una instancia del objeto projectilePrefab en el punto de origen del arma.
        GameObject projectile = Instantiate(projectilePrefab, weaponOriginPosition, Quaternion.identity);



        // Agrega fuerza al objeto proyectil en la direcci�n de la c�mara.
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(shotDirection * shotForce, ForceMode.Impulse);

        }

        // Destruye el proyectil despu�s de un tiempo para evitar que llenen la escena.
        Destroy(projectile, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Detecte collision");
        Rigidbody rb = GetComponent<Rigidbody>();
        
        // Verifica si la colisi�n involucra un objeto con el tag "enemy".
        if (other.CompareTag("enemy"))
        {    
                Debug.Log("Pse a 0");
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                    
        }
       
        if (other.gameObject.layer == collisionLayer)
            Debug.Log("Detecte collision layer ");
        {
                Debug.Log("Pse a 0 con gorund ");
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                  
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





    
