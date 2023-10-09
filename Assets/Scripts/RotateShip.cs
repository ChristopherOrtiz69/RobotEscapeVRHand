using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class RotateShip : MonoBehaviour
{
    public Transform objectToRotate; // Asigna el objeto que deseas rotar desde el Inspector.
    public float viewAngle = 45f; // Ángulo de visión horizontal.
    public float maxVerticalRotation = 45f; // Máximo ángulo de rotación hacia arriba.
    public float minVerticalRotation = -45f; // Máximo ángulo de rotación hacia abajo.
    public float noRotateRadius = 5f; // Radio del área donde no se aplica rotación.

    private Transform playerCamera; // Referencia a la cámara del jugador (cámara de VR).

    private void Start()
    {
        // Obtén la cámara de VR (asegúrate de que esté configurada en tu escena).
        playerCamera = Camera.main.transform;
    }

    private void Update()
    {
        // Obtiene la dirección de la cámara en VR.
        Vector3 cameraForward = playerCamera.forward;

        // Calcula el ángulo entre la dirección de la cámara y el objeto a rotar.
        float angleToCamera = Vector3.Angle(objectToRotate.forward, cameraForward);

        // Comprueba si el ángulo está dentro del rango de visión horizontal.
        if (angleToCamera <= viewAngle)
        {
            // Comprueba si la distancia al objeto es mayor que el radio de no rotación.
            float distanceToCamera = Vector3.Distance(objectToRotate.position, playerCamera.position);
            if (distanceToCamera > noRotateRadius)
            {
                // Calcula la rotación actual del objeto.
                Quaternion currentRotation = objectToRotate.rotation;

                // Calcula la rotación deseada hacia la dirección de la cámara.
                Quaternion targetRotation = Quaternion.LookRotation(cameraForward);

                // Limita la rotación vertical.
                float verticalRotation = targetRotation.eulerAngles.x;
                verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation);
                targetRotation = Quaternion.Euler(verticalRotation, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);

                // Aplica la rotación gradualmente.
                objectToRotate.rotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime);
            }
        }
    }
}