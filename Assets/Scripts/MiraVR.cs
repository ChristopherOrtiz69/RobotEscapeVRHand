using UnityEngine;

public class MiraVR : MonoBehaviour
{
    public float distanceFromCamera = 1.0f; // Ajusta la distancia deseada desde la c�mara.

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main; // Aseg�rate de que tu c�mara principal est� etiquetada como "MainCamera".
    }

    private void Update()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * distanceFromCamera;
    }
}