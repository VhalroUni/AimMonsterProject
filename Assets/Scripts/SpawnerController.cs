using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public EnemySpawner spawnArea1;
    public EnemySpawner spawnArea2;
    public EnemySpawner spawnArea3;
    public EnemySpawner spawnArea4;

    private EnemySpawner[] allSpawnAreas;
    private EnemySpawner currentActiveArea;

    void Start()
    {
        // Almacena todas las �reas de spawneo en un arreglo
        allSpawnAreas = new EnemySpawner[] { spawnArea1, spawnArea2, spawnArea3, spawnArea4 };

        // Desactiva todas las �reas de spawneo al inicio
        DeactivateAllSpawnAreas();

        // Activa una de las �reas de spawneo de forma aleatoria
        ActivateRandomSpawnArea();
    }

    void Update()
    {
        // Si la zona de spawneo actual ya no est� activa, activa otra de forma aleatoria
        if (currentActiveArea != null && !currentActiveArea.enabled)
        {
            ActivateRandomSpawnArea();
        }
    }

    void DeactivateAllSpawnAreas()
    {
        foreach (var area in allSpawnAreas)
        {
            area.enabled = false;
        }
    }

    void ActivateRandomSpawnArea()
    {
        // Selecciona una de las �reas de spawneo al azar
        int randomIndex = Random.Range(0, allSpawnAreas.Length);
        currentActiveArea = allSpawnAreas[randomIndex];

        // Activa el �rea seleccionada y desactiva las dem�s
        foreach (var area in allSpawnAreas)
        {
            area.enabled = (area == currentActiveArea);
        }
    }
}
