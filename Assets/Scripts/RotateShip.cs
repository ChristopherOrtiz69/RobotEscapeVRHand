using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShip : MonoBehaviour
{
    public Transform objetoARotar; // Objeto que se va a rotar
    public float velocidadRotacion = 45.0f; // Velocidad de rotaci�n en grados por segundo
    public float anguloUmbral = 30.0f; // �ngulo en grados para activar la rotaci�n

    void Update()
    {
        // Verifica si el objeto a rotar est� asignado
        if (objetoARotar != null)
        {
            // Calcula el �ngulo entre la direcci�n de la c�mara y la direcci�n del objeto
            Vector3 direccionCamara = Camera.main.transform.forward;
            Vector3 direccionObjeto = (objetoARotar.position - Camera.main.transform.position).normalized;

            // Calcula el �ngulo entre las dos direcciones en el eje Y
            float anguloY = Vector3.SignedAngle(direccionCamara, direccionObjeto, Vector3.up);

            // Activa la rotaci�n si el �ngulo supera el umbral
            if (Mathf.Abs(anguloY) > anguloUmbral)
            {
                // Invierte la direcci�n de rotaci�n en funci�n del �ngulo calculado
                float direccionRotacion = Mathf.Sign(anguloY);

                // Calcula la rotaci�n deseada en funci�n del �ngulo calculado y la direcci�n de rotaci�n
                Quaternion rotacionDeseada = Quaternion.Euler(0, direccionRotacion * anguloUmbral, 0);

                // Aplica la rotaci�n al objeto
                objetoARotar.rotation = Quaternion.RotateTowards(objetoARotar.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
            }
        }
    }
}