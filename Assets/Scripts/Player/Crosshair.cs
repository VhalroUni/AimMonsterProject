using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Variable pública para la textura de la mira
    public Texture2D crosshairTexture;

    // Tamaño de la mira
    public float crosshairSize = 32.0f;

    // Singleton instance
    public static Crosshair Instance { get; private set; }

    void Awake()
    {
        // Implementación del Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Ocultar el cursor del sistema
        Cursor.visible = false;
        // Mantener el cursor dentro de la ventana del juego
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        // Siempre asegurarse de que el cursor esté oculto
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnGUI()
    {
        // Obtener la posición del ratón
        Vector3 mousePosition = Input.mousePosition;

        // Calcular la posición de la mira para que esté centrada en el ratón
        float xMin = mousePosition.x - (crosshairSize / 2);
        float yMin = Screen.height - mousePosition.y - (crosshairSize / 2); // Invertir la coordenada Y

        // Dibujar la textura de la mira en la posición calculada
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairSize, crosshairSize), crosshairTexture);
    }
}
