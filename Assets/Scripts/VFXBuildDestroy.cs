using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXBuildDestroy : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto que se activar� al tocar el trigger

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entr� en el trigger tiene el tag "misil"
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
