using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXBuildDestroy : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto que se activará al tocar el trigger

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en el trigger tiene el tag "misil"
        if (other.CompareTag("misil"))
        {
            // Activa el objeto
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
