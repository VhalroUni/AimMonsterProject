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
    public PauseMenuManager deathMenu;
    public int monsterType;
    private ScoreManager scoreManager;

    private void Start()
    {
        health = maxHealth;
        lastHit = -invulnerabilityDuration;
        gameController = FindObjectOfType<GameController>();
        scoreManager = FindObjectOfType<ScoreManager>();
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
                deathMenu.ShowDeathMenu();
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
                
                switch(monsterType)
                {
                    
                    case 0: scoreManager.AddScore(25); break;
                    case 1: scoreManager.AddScore(100); break;
                    case 2: scoreManager.AddScore(125); break;
                    case 3: scoreManager.AddScore(500); break;
                    case 4: scoreManager.AddScore(1000); break;
                    case 5: scoreManager.AddScore(250); break;
                    case 6: break;
                }
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
