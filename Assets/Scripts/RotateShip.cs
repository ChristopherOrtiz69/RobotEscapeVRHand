using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShip : MonoBehaviour
{
    public Transform objetoARotar; // Objeto que se va a rotar
    public float velocidadRotacion = 45.0f; // Velocidad de rotación en grados por segundo
    public float anguloUmbral = 30.0f; // Ángulo en grados para activar la rotación

    void Update()
    {
        // Verifica si el objeto a rotar está asignado
        if (objetoARotar != null)
        {
            // Calcula el ángulo entre la dirección de la cámara y la dirección del objeto
            Vector3 direccionCamara = Camera.main.transform.forward;
            Vector3 direccionObjeto = (objetoARotar.position - Camera.main.transform.position).normalized;

            // Calcula el ángulo entre las dos direcciones en el eje Y
            float anguloY = Vector3.SignedAngle(direccionCamara, direccionObjeto, Vector3.up);

            // Activa la rotación si el ángulo supera el umbral
            if (Mathf.Abs(anguloY) > anguloUmbral)
            {
                // Invierte la dirección de rotación en función del ángulo calculado
                float direccionRotacion = Mathf.Sign(anguloY);

                // Calcula la rotación deseada en función del ángulo calculado y la dirección de rotación
                Quaternion rotacionDeseada = Quaternion.Euler(0, direccionRotacion * anguloUmbral, 0);

                // Aplica la rotación al objeto
                objetoARotar.rotation = Quaternion.RotateTowards(objetoARotar.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
            }
        }
    }
}