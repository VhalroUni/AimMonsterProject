using UnityEngine;
using System.Collections;

public class EnemiGoldIntro : MonoBehaviour
{
    public Transform startPos; // Asigna aquí el GameObject vacío que representa la posición inicial
    public Transform endPos; // Asigna aquí el GameObject vacío que representa la posición final
    public float moveTime = 6f; // Tiempo en segundos para mover al enemigo de inicio a fin
    public float waitTime = 20f; // Tiempo en segundos que el enemigo esperará en la posición final

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime;
    private bool movingToEnd = true;

    void Start()
    {
        // Inicializamos las posiciones y el tiempo de inicio
        startPosition = startPos.position;
        endPosition = endPos.position;
        transform.position = startPosition; // Colocamos al enemigo en la posición inicial
        startTime = Time.time;
        StartCoroutine(MoveAndWait());
    }

    IEnumerator MoveAndWait()
    {
        while (true)
        {
            // Movimiento del enemigo
            float distanceCovered = (Time.time - startTime) / moveTime;
            if (movingToEnd)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, distanceCovered);
            }
            else
            {
                transform.position = Vector3.Lerp(endPosition, startPosition, distanceCovered);
            }

            // Si ha llegado al final, esperamos
            if (distanceCovered >= 1f)
            {
                // Giramos al enemigo 180 grados
                transform.Rotate(0f, 180f, 0f);

                yield return new WaitForSeconds(waitTime); // Esperamos el tiempo especificado

                // Reiniciamos para volver a empezar
                startTime = Time.time;
                movingToEnd = !movingToEnd; // Cambiamos la dirección del movimiento
                transform.position = movingToEnd ? startPosition : endPosition; // Colocamos al enemigo en la posición correcta
            }

            yield return null; // Esperamos un frame antes de continuar el bucle
        }
    }
}

