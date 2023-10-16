using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class MissileSpawner : MonoBehaviour
{
    public GameObject missilePrefab; // Asigna la copia del Prefab del misil en el Inspector
    public Transform spawnPoint;  // El punto donde aparecerán los misiles

    private float minSpawnInterval = 4f; // Tiempo mínimo de spawn (en segundos)
    private float maxSpawnInterval = 15f; // Tiempo máximo de spawn (en segundos)

    private void Start()
    {
        // Comienza el proceso de spawn de misiles
        StartCoroutine(SpawnMissilesRandomly());
    }

    private IEnumerator SpawnMissilesRandomly()
    {
        while (true)
        {
            // Calcula un tiempo de espera aleatorio entre minSpawnInterval y maxSpawnInterval
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Espera durante el tiempo calculado antes de instanciar el misil
            yield return new WaitForSeconds(spawnInterval);

            // Instancia una copia del Prefab del misil en el punto de spawn
            GameObject newMissile = Instantiate(missilePrefab, spawnPoint.position, Quaternion.identity);
            newMissile.SetActive(false); // Desactiva el objeto recién instanciado

            // Activa el objeto después de un tiempo aleatorio
            float activationDelay = Random.Range(1f, 5f); // Tiempo aleatorio para activar
            StartCoroutine(ActivateMissileAfterDelay(newMissile, activationDelay));
        }
    }

    private IEnumerator ActivateMissileAfterDelay(GameObject missile, float delay)
    {
        yield return new WaitForSeconds(delay);
        missile.SetActive(true); // Activa el objeto después del tiempo de espera
    }
}