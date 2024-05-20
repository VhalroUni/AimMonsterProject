using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public bool isPlayer;
    public float invulnerabilityDuration = 2.0f; 
    private float lastHit; // Variable que define cuando fue recibido el último golpe
    private GameController gameController;

    private void Start()
    {
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
            Debug.Log("El jugador recibe daño");

            if (health <= 0)
            {
                health = 0;
                Debug.Log("El jugador ha muerto.");
                gameController.currentState = GameState.GameOver;
                gameController.HandleStateChange(); 
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
}
