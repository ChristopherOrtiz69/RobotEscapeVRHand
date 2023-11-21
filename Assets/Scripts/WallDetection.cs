using UnityEngine;

public class WallDetection : MonoBehaviour
{
    public string playerTag = "Player";
    public Camera mainCamera; // Arrastra la c�mara principal aqu� desde el inspector.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Se detect� un objeto con el tag "Player"
            CambiarColorCamaraNegro();
        }
    }

    private void CambiarColorCamaraNegro()
    {
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = Color.black;

            // Puedes agregar aqu� cualquier otra l�gica que desees cuando colisiona con el jugador.
        }
    }
}
