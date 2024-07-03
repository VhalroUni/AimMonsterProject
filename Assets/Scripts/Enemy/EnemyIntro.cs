using UnityEngine;

public class EnemyIntro : MonoBehaviour
{
    // Variable pública para las partículas
    public GameObject particleEffect;

    // Función para hacer que el enemigo desaparezca y active las partículas
    public void Disappear()
    {
        // Si hay un efecto de partículas asignado, lo activamos
        if (particleEffect != null)
        {
            // Instanciamos las partículas en la posición del enemigo
            GameObject particles = Instantiate(particleEffect, transform.position, Quaternion.identity);
            // Destruimos las partículas después de un tiempo (ajustable según lo necesites)
            Destroy(particles, 2f);
        }

        // Desactivamos al enemigo
        gameObject.SetActive(false);
    }

    // Método para detectar cuando se pulsa sobre el enemigo
    private void OnMouseDown()
    {
        // Llamamos a la función Disappear
        Disappear();
    }
}