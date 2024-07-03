using UnityEngine;

public class EnemyIntro : MonoBehaviour
{
    // Variable p�blica para las part�culas
    public GameObject particleEffect;

    // Funci�n para hacer que el enemigo desaparezca y active las part�culas
    public void Disappear()
    {
        // Si hay un efecto de part�culas asignado, lo activamos
        if (particleEffect != null)
        {
            // Instanciamos las part�culas en la posici�n del enemigo
            GameObject particles = Instantiate(particleEffect, transform.position, Quaternion.identity);
            // Destruimos las part�culas despu�s de un tiempo (ajustable seg�n lo necesites)
            Destroy(particles, 2f);
        }

        // Desactivamos al enemigo
        gameObject.SetActive(false);
    }

    // M�todo para detectar cuando se pulsa sobre el enemigo
    private void OnMouseDown()
    {
        // Llamamos a la funci�n Disappear
        Disappear();
    }
}