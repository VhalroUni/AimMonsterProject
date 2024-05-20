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
        nextspawntime = Time.time + InitialSpawnTime;  // Activa una de las áreas de spawneo de forma aleatoria
    }
    void Update()
    {
        if (Time.time >= nextspawntime) //verifica si es tiempo de spawnear un enemigo
        {
            SpawnEnemyAtRandomSpawner();
            nextspawntime = Time.time + (TimeToSpawn + Random.Range(-RandomTimeOffset,RandomTimeOffset));  // Calcula el tiempo para el próximo spawn sumando la frecuencia de spawn
        }
    }
    void SpawnEnemyAtRandomSpawner()
    {
        int randomIndex = Random.Range(0, allSpawnAreas.Length);  // Selecciona una de las áreas de spawneo al azar
        currentActiveArea = allSpawnAreas[randomIndex];
        currentActiveArea.SpawnEnemy(EnemyPrefab);    
    }
}