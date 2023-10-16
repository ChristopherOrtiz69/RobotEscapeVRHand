using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class MissileSpawner : MonoBehaviour
{
    public Missile missile; // Asigna el objeto del misil en el Inspector
    public Transform spawnPoint;  // El punto donde aparecerán los misiles

    private float minSpawnInterval = 7f; // Tiempo mínimo de spawn (en segundos)
    private float maxSpawnInterval = 16f; // Tiempo máximo de spawn (en segundos)

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

            // Instancia un nuevo misil en el punto de spawn
            Instantiate(missile, spawnPoint.position, Quaternion.identity);
        }
    }
}
