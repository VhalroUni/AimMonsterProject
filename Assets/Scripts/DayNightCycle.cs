using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    [System.Serializable]
    public struct TimeOfDay
    {
        public string name;
        public float duration; // Duración del segmento de tiempo en segundos
        public Color color;
    }

    public TimeOfDay[] timeOfDayColors;
    public Light directionalLight;
    public float transitionDuration = 5f; // Duración de la transición entre colores

    private float elapsedTime = 0f;
    private int currentIndex = 0;
    private Color startColor;
    private Color targetColor;
    private bool inTransition = false;
    private float transitionStartTime;

    void Start()
    {
        // Configuramos el primer color al inicio
        SetNextColor();
    }

    void Update()
    {
        if (!inTransition)
        {
            // No sumamos directamente Time.deltaTime a elapsedTime
            elapsedTime = Time.time - transitionStartTime;

            if (elapsedTime >= timeOfDayColors[currentIndex].duration)
            {
                SetNextColor();
            }
        }
        else
        {
            float transitionProgress = (Time.time - transitionStartTime) / transitionDuration;
            directionalLight.color = Color.Lerp(startColor, targetColor, transitionProgress);

            if (transitionProgress >= 1f)
            {
                inTransition = false;
                elapsedTime = 0f;
            }
        }
    }

    void SetNextColor()
    {
        // Incrementamos el índice para pasar al siguiente color
        currentIndex = (currentIndex + 1) % timeOfDayColors.Length;

        startColor = directionalLight.color;
        targetColor = timeOfDayColors[currentIndex].color;
        transitionStartTime = Time.time;
        inTransition = true;

        // Establecemos la duración del tiempo de transición igual a la duración del segmento de tiempo
        transitionDuration = timeOfDayColors[currentIndex].duration;

        // Mostramos información en la consola (opcional)
        Debug.Log("Tiempo del color: " + timeOfDayColors[currentIndex].name + "\nColor: " + timeOfDayColors[currentIndex].color);
    }
}
