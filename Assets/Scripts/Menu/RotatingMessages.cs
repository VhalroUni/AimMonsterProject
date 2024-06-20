using UnityEngine;
using TMPro;
using System.Collections;

public class RotatingMessages : MonoBehaviour
{
    public TMP_Text messageText; // Variable pública para asignar el componente TMP_Text desde el Inspector.
    public string[] messages; // Llena esta lista con tus mensajes desde el Inspector.
    public float animationSpeed = 1.0f; // Velocidad de la animación de "respiración".

    private int currentMessageIndex = 0;

    void Start()
    {
        // Selecciona un mensaje aleatorio al iniciar la escena.
        if (messages.Length > 0)
        {
            currentMessageIndex = Random.Range(0, messages.Length);
            messageText.text = messages[currentMessageIndex];
        }

        // Inicia la animación de "respiración".
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        while (true)
        {
            // Anima el tamaño del texto de grande a pequeño y de regreso.
            yield return StartCoroutine(ScaleText(Vector3.one * 1.2f, animationSpeed));
            yield return StartCoroutine(ScaleText(Vector3.one, animationSpeed));
        }
    }

    IEnumerator ScaleText(Vector3 targetScale, float duration)
    {
        Vector3 startScale = messageText.transform.localScale;
        float time = 0;

        while (time < duration)
        {
            messageText.transform.localScale = Vector3.Lerp(startScale, targetScale, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        messageText.transform.localScale = targetScale;
    }
}
