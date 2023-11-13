using UnityEngine;

public class MiraVR : MonoBehaviour
{
    public float distanceFromCamera = 1.0f; // Ajusta la distancia deseada desde la cámara.

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // Asegúrate de que tu cámara principal esté etiquetada como "MainCamera".
    }

    private void Update()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
    }
}