using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform Target;
    public float spawnRate = 1f; // Frecuencia de spawn
    public Vector3 spawnBoxSize = new Vector3(10f, 5f, 10f); // Tamaño del cubo de spawn
    public Transform[] spawnAreas; // Lista de áreas de spawn


    private float nextSpawnTime; // Tiempo en que se spawneará el próximo enemigo

    public void SpawnEnemy(GameObject EnemyPrefab)
    {
        // Genera una posición aleatoria dentro del cubo de spawn
        Vector3 spawnPosition = transform.position + new Vector3(
            Random.Range(-spawnBoxSize.x / 2f, spawnBoxSize.x / 2f),
            Random.Range(-spawnBoxSize.y / 2f, spawnBoxSize.y / 2f),
            Random.Range(-spawnBoxSize.z / 2f, spawnBoxSize.z / 2f));

        // Spawnear el enemigo en la posición aleatoria
        GameObject Enemy = Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
        Enemy.GetComponent<EnemyController>().Objective = Target;
    }

    // Dibuja un gizmo en el editor para visualizar el área de spawn
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnBoxSize);
    }
}
