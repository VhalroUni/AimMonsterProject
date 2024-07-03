using UnityEngine;

public class ShowTextOnEnemiesClick : MonoBehaviour
{
    // Variable pública para el GameObject que contiene el texto
    public GameObject messageObject;

    // Variable pública para el array de enemigos
    public GameObject[] enemies;

    // Array para controlar si cada enemigo ha sido pulsado
    private bool[] enemiesClicked;

    void Start()
    {
        // Inicializar el texto como oculto
        if (messageObject != null)
        {
            messageObject.SetActive(false);
            Debug.Log("Message object is hidden");
        }

        // Inicializar el array de control de enemigos pulsados
        enemiesClicked = new bool[enemies.Length];
        Debug.Log("Enemies clicked array initialized");
    }

    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            // Detectar si se ha hecho clic en el enemigo
            if (enemies[i] != null && Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject == enemies[i])
                    {
                        enemiesClicked[i] = true;
                        Debug.Log("Enemy " + i + " clicked");
                    }
                }
            }
        }

        // Verificar si todos los enemigos han sido pulsados
        if (AllEnemiesClicked() && messageObject != null)
        {
            // Mostrar el texto
            messageObject.SetActive(true);
            Debug.Log("All enemies clicked, showing message object");
        }
    }

    // Método para verificar si todos los enemigos han sido pulsados
    bool AllEnemiesClicked()
    {
        foreach (bool clicked in enemiesClicked)
        {
            if (!clicked)
                return false;
        }
        return true;
    }
}


