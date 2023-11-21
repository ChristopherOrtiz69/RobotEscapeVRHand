using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public string playerTag = "Player";
    public Camera mainCamera; // Arrastra la cámara principal aquí desde el inspector.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Se detectó un objeto con el tag "Player"
            CambiarColorCamaraNegro();
        }
    }

    private void CambiarColorCamaraNegro()
    {
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = Color.black;

            // Puedes agregar aquí cualquier otra lógica que desees cuando colisiona con el jugador.
        }
    }
}
