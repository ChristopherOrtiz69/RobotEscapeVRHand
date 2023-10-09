using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotateShip : MonoBehaviour
{
    public Transform objectToRotate; // Asigna el objeto que deseas rotar desde el Inspector.
    public float viewAngle = 45f; // �ngulo de visi�n horizontal.
    public float maxVerticalRotation = 45f; // M�ximo �ngulo de rotaci�n hacia arriba.
    public float minVerticalRotation = -45f; // M�ximo �ngulo de rotaci�n hacia abajo.
    public float noRotateRadius = 5f; // Radio del �rea donde no se aplica rotaci�n.

    private Transform playerCamera; // Referencia a la c�mara del jugador (c�mara de VR).

    private void Start()
    {
        // Obt�n la c�mara de VR (aseg�rate de que est� configurada en tu escena).
        playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        // Obtiene la direcci�n de la c�mara en VR.
        Vector3 cameraForward = playerCamera.forward;

        // Calcula el �ngulo entre la direcci�n de la c�mara y el objeto a rotar.
        float angleToCamera = Vector3.Angle(objectToRotate.forward, cameraForward);

        // Comprueba si el �ngulo est� dentro del rango de visi�n horizontal.
        if (angleToCamera <= viewAngle)
        {
            // Comprueba si la distancia al objeto es mayor que el radio de no rotaci�n.
            float distanceToCamera = Vector3.Distance(objectToRotate.position, playerCamera.position);
            if (distanceToCamera > noRotateRadius)
            {
                // Calcula la rotaci�n actual del objeto.
                Quaternion currentRotation = objectToRotate.rotation;

                // Calcula la rotaci�n deseada hacia la direcci�n de la c�mara.
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward);

                // Limita la rotaci�n vertical.
                float verticalRotation = targetRotation.eulerAngles.x;
                verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);
                targetRotation = Quaternion.Euler(verticalRotation, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

                // Aplica la rotaci�n gradualmente.
                objectToRotate.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime);
            }
        }
    }
}