using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour
{
    public GameObject particlesPrefab; // Asigna el prefab desde el Inspector
    public GameObject enemyParticlesPrefab; // Asigna el prefab para las part�culas del enemigo desde el Inspector
    public float particleLifetime = 1.0f; // Tiempo de vida de las part�culas en segundos

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detecta si se hace clic con el bot�n izquierdo del mouse
        {
            if (!IsPointerOverUIObject())
            {
                Debug.Log("No se hizo clic en un UI");
                HandleClick();
            }
            else
            {
                Debug.Log("Se hizo clic en un UI");
            }
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (var result in results)
        {
            Debug.Log("Hit UI element: " + result.gameObject.name);
            if (result.gameObject.CompareTag("UI"))
            {
                return true;
            }
        }
        return false;
    }

    private void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Raycast hit: " + hit.transform.name);
            if (hit.transform.gameObject.GetComponent<EnemyController>() == null)
            {
                // No se hizo clic en un enemigo
                SoundManager.instance.PlayEarthSound();

                // Instancia el prefab de part�culas
                GameObject particles = Instantiate(particlesPrefab, hit.point, Quaternion.identity);
                Destroy(particles, particleLifetime); // Destruye las part�culas despu�s de 1 segundo
            }
            else
            {
                Debug.Log("Clic en enemigo");

                // Instancia el prefab de part�culas para el enemigo
                GameObject enemyParticles = Instantiate(enemyParticlesPrefab, hit.point, Quaternion.identity);
                Destroy(enemyParticles, particleLifetime); // Destruye las part�culas del enemigo despu�s de 1 segundo
            }
        }
        else
        {
            // No se hizo clic en ning�n objeto
            Debug.Log("Raycast no hit");
            SoundManager.instance.PlayEarthSound();
        }
    }
}
