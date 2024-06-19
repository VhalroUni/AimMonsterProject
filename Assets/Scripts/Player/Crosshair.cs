using UnityEngine;

public class Crosshair : MonoBehaviour
{
    // Variable p�blica para la textura de la mira
    public Texture2D crosshairTexture;

    // Tama�o de la mira
    public float crosshairSize = 32.0f;

    // Singleton instance
    public static Crosshair Instance { get; private set; }

    void Awake()
    {
        // Implementaci�n del Singleton
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
        // Siempre asegurarse de que el cursor est� oculto
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnGUI()
    {
        // Obtener la posici�n del rat�n
        Vector3 mousePosition = Input.mousePosition;

        // Calcular la posici�n de la mira para que est� centrada en el rat�n
        float xMin = mousePosition.x - (crosshairSize / 2);
        float yMin = Screen.height - mousePosition.y - (crosshairSize / 2); // Invertir la coordenada Y

        // Dibujar la textura de la mira en la posici�n calculada
        GUI.DrawTexture(new Rect(xMin, yMin, crosshairSize, crosshairSize), crosshairTexture);
    }
}
