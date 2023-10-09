using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;
    public float speed = 5.0f;
    public float rotationSpeed = 5.0f;
    public float stoppingDistance = 1.0f;
    public float avoidanceDistance = 2.0f; // Distancia para evitar objetos con el tag "enemy"
    public float sideRayLength = 1.0f;    // Longitud del raycast hacia los lados
    public float sideRayOffset = 0.5f;    // Offset desde el centro del objeto hacia los lados

    private void Update()
    {
        if (target == null)
        {
            Debug.LogError("No se ha asignado un objetivo.");
            return;
        }

        // Calcula la dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;

        // Calcula la rotación hacia la dirección del objetivo
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Aplica la rotación gradualmente
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Calcula la distancia al objetivo
        float distance = Vector3.Distance(transform.position, target.position);

        // Si estamos lo suficientemente cerca del objetivo, reduce la velocidad para la llegada suave
        if (distance <= stoppingDistance)
        {
            float arrivalSpeed = Mathf.Lerp(0, speed, distance / stoppingDistance);
            transform.position += transform.forward * arrivalSpeed * Time.deltaTime;
        }
        else
        {
            // Si estamos lejos del objetivo, aplica velocidad máxima
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        // Raycast hacia adelante para evitar objetos con el tag "enemy"
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidanceDistance) && hit.collider.CompareTag("enemy"))
        {
            // Si detecta un objeto con el tag "enemy" en la dirección del movimiento, reduce la velocidad
            float avoidanceSpeed = speed * 0.5f; // Puedes ajustar este valor
            transform.position += -transform.forward * avoidanceSpeed * Time.deltaTime;
        }

        // Raycast hacia los lados para evitar objetos con el tag "enemy"
        RaycastHit leftHit;
        RaycastHit rightHit;

        Vector3 leftRayOrigin = transform.position + transform.right * sideRayOffset;
        Vector3 rightRayOrigin = transform.position - transform.right * sideRayOffset;

        if (Physics.Raycast(leftRayOrigin, transform.forward, out leftHit, sideRayLength) && leftHit.collider.CompareTag("enemy"))
        {
            // Si detecta un objeto con el tag "enemy" en el lado izquierdo, ajusta la dirección para evitar colisiones
            direction = Vector3.RotateTowards(direction, transform.right, Mathf.PI / 4, 0);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (Physics.Raycast(rightRayOrigin, transform.forward, out rightHit, sideRayLength) && rightHit.collider.CompareTag("enemy"))
        {
            // Si detecta un objeto con el tag "enemy" en el lado derecho, ajusta la dirección para evitar colisiones
            direction = Vector3.RotateTowards(direction, -transform.right, Mathf.PI / 4, 0);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}