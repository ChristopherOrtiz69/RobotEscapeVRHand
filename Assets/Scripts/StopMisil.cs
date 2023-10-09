using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMisil : MonoBehaviour
{
    public LayerMask collisionLayer;
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión involucra un objeto con el tag "enemy".
        if (collision.gameObject.CompareTag("enemy"))
        {
            // Destruye el objeto enemigo.
            Destroy(collision.gameObject);

            // Detiene completamente el objeto actual.
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.Sleep();
            }
        }
        if (collision.gameObject.layer == collisionLayer)
        {
            // Detiene completamente el objeto actual.
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.Sleep();
            }
        }
    }



}
