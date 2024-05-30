using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    public bool isPlayer;
    public float invulnerabilityDuration = 2.0f;
    private float lastHit; // Variable que define cuando fue recibido el último golpe
    private GameController gameController;
    public Sprite redHeart;
    public Sprite emptyHeart;
    public Image[] hearts;
    public DeathMenuManager deathMenuManager;

    private void Start()
    {
        health = maxHealth;
        lastHit = -invulnerabilityDuration;
        gameController = FindObjectOfType<GameController>();
    }
    public void TakeDamage(int damage)
    {
        if (isPlayer)
        {
            if (Time.time - lastHit < invulnerabilityDuration) //Si el tiempo actual - El tiempo del ultimo golpe es menor que el tiempo de invulnerabilidad0
            {
                Debug.Log("El jugador es invulnerable");
                return;
            }
            health -= damage;
            UpdateHearts();
            Debug.Log("El jugador recibe daño");


            if (health <= 0)
            {
                health = 0;
                Debug.Log("El jugador ha muerto.");
                gameController.currentState = GameState.GameOver;
                gameController.HandleStateChange();
                deathMenuManager.ShowMenu();
            }
            else
            {
                Debug.Log("El jugador sigue vivo");
            }

            lastHit = Time.time;
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Debug.Log("El enemigo ha muerto");
            }
        }
    }
    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = redHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

}
