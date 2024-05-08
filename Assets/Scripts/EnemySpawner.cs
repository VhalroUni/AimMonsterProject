using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform Target;
    public GameObject enemyPrefab; // Prefabricado del enemigo que quieres spawnear
    public float spawnRate = 1f; // Frecuencia de spawn
    public Vector3 spawnBoxSize = new Vector3(10f, 5f, 10f); // Tama�o del cubo de spawn
    
    private float nextSpawnTime; // Tiempo en que se spawnear� el pr�ximo enemigo

    void Update()
    {
        // Verifica si es tiempo de spawnear un enemigo
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            // Calcula el tiempo para el pr�ximo spawn sumando la frecuencia de spawn
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // Genera una posici�n aleatoria dentro del cubo de spawn
        Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnBoxSize.x / 2f, spawnBoxSize.x / 2f),
            Random.Range(-spawnBoxSize.y / 2f, spawnBoxSize.y / 2f),
            Random.Range(-spawnBoxSize.z / 2f, spawnBoxSize.z / 2f));

        // Spawnear el enemigo en la posici�n aleatoria
        GameObject Enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy.GetComponent<EnemyController>().Objective = Target;
    }

    // Dibuja un gizmo en el editor para visualizar el �rea de spawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnBoxSize);
    }
}
