using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
    public float blinkDuration = 0.1f; // Duración de cada parpadeo
    public int blinkCount = 5; // Número de parpadeos
    public GameObject model; // Objeto hijo que contiene el modelo 3D del personaje

    private EnemyController enemyController;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        health = maxHealth;
        lastHit = -invulnerabilityDuration;
        gameController = FindObjectOfType<GameController>();

        if (model != null)
        {
            meshRenderer = model.GetComponent<MeshRenderer>();
        }

        if (!isPlayer)
        {
            enemyController = GetComponent<EnemyController>();
        }
    }

    public void TakeDamage(int damage)
    {
        if (isPlayer)
        {
            if (Time.time - lastHit < invulnerabilityDuration) // Si el tiempo actual - El tiempo del último golpe es menor que el tiempo de invulnerabilidad
            {
                Debug.Log("El jugador es invulnerable");
                return;
            }
            health -= damage;
            UpdateHearts();
            Debug.Log("El jugador recibe daño");

            StartCoroutine(Blink());

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
                CheckSpecialEnemy();
            }
        }
    }

    private void CheckSpecialEnemy()
    {
        if (enemyController != null && enemyController.enemyIndex == 4)
        {
            Health playerHealth = FindObjectOfType<Health>();
            if (playerHealth != null && playerHealth.isPlayer)
            {
                playerHealth.health += 1;
                playerHealth.UpdateHearts();
                Debug.Log("El jugador ha ganado 1 de vida por eliminar al enemigo con índice 4");
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

    IEnumerator Blink()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            SetMeshRendererOpacity(0);
            yield return new WaitForSeconds(blinkDuration);
            SetMeshRendererOpacity(1);
            yield return new WaitForSeconds(blinkDuration);
        }
    }

    void SetMeshRendererOpacity(float opacity)
    {
        if (meshRenderer != null)
        {
            Color color = meshRenderer.material.color;
            color.a = opacity;
            meshRenderer.material.color = color;
        }
    }
}
