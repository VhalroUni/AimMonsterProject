using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour
{
    private float nextspawntime;
    public float InitialSpawnTime;
    public float TimeToSpawn;
    public float RandomTimeOffset;
    public GameObject EnemyPrefab;
    public EnemySpawner[] allSpawnAreas;
    
    private EnemySpawner currentActiveArea;

    void Start()
    {
        // Activa una de las áreas de spawneo de forma aleatoria
        // SpawnEnemyAtRandomSpawner();
        nextspawntime = Time.time + InitialSpawnTime;

    }

    void Update()
    {

        //verifica si es tiempo de spawnear un enemigo
        if (Time.time >= nextspawntime)
        {
            SpawnEnemyAtRandomSpawner();
            // calcula el tiempo para el próximo spawn sumando la frecuencia de spawn
            nextspawntime = Time.time + (TimeToSpawn + Random.Range(-RandomTimeOffset,RandomTimeOffset));
        }

    }
    
    void SpawnEnemyAtRandomSpawner()
    {
        // Selecciona una de las áreas de spawneo al azar
        int randomIndex = Random.Range(0, allSpawnAreas.Length);
        currentActiveArea = allSpawnAreas[randomIndex];

        currentActiveArea.SpawnEnemy(EnemyPrefab);    
    }
}