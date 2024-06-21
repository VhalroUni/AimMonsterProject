using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnemies : MonoBehaviour
{
    // Lista de enemigos a verificar
    public GameObject[] enemies;

    void Update()
    {
        // Verificar si todos los enemigos han sido destruidos
        if (AllEnemiesDestroyed())
        {
            // Cargar la escena del menú principal
            SceneManager.LoadScene("MainMenu");
        }
    }

    bool AllEnemiesDestroyed()
    {
        // Verificar cada enemigo en la lista
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                // Si algún enemigo no ha sido destruido, retornar false
                return false;
            }
        }
        // Todos los enemigos han sido destruidos
        return true;
    }
}
