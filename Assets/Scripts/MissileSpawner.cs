using System.Collections;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab; // Asigna la copia del Prefab del misil en el Inspector
    public Transform spawnPoint; // El punto donde aparecer�n los misiles
    public float playerDetectionRadius = 10f; // Radio de detecci�n del jugador
    public string playerTag = "Player"; // Tag del jugador

    private float minSpawnInterval = 0f; // Tiempo m�nimo de spawn (en segundos)
    private float maxSpawnInterval = 3f; // Tiempo m�ximo de spawn (en segundos)

    private void Start()
    {
        // Comienza el proceso de spawn de misiles
        StartCoroutine(SpawnMissilesRandomly());
    }

    private IEnumerator SpawnMissilesRandomly()
    {
        while (true)
        {
            // Espera durante el tiempo calculado antes de instanciar el misil
            yield return new WaitUntil(() => IsPlayerInRadius());

            // Calcula un tiempo de espera aleatorio entre minSpawnInterval y maxSpawnInterval
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Espera durante el tiempo calculado antes de instanciar el misil
            yield return new WaitForSeconds(spawnInterval);

            // Instancia una copia del Prefab del misil en el punto de spawn
            GameObject newMissile = Instantiate(missilePrefab, spawnPoint.position, Quaternion.identity);
            newMissile.SetActive(false); // Desactiva el objeto reci�n instanciado

            // Activa el objeto despu�s de un tiempo aleatorio
            float activationDelay = Random.Range(0f, 0f); // Tiempo aleatorio para activar
            StartCoroutine(ActivateMissileAfterDelay(newMissile, activationDelay));
        }
    }

    private IEnumerator ActivateMissileAfterDelay(GameObject missile, float delay)
    {
        yield return new WaitForSeconds(delay);
        missile.SetActive(true); // Activa el objeto despu�s del tiempo de espera
    }

    private bool IsPlayerInRadius()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, playerDetectionRadius);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag(playerTag))
            {
                return true;
            }
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        // Dibuja el radio de detecci�n del jugador
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playerDetectionRadius);
    }
}
