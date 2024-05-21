using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public bool isPlayer;
    public float invulnerabilityDuration = 2.0f; // Duración de la invulnerabilidad en segundos
    private float lastHitTime; // Tiempo del último golpe recibido
    private GameController gameController;

    private void Start()
    {
        lastHitTime = -invulnerabilityDuration; 
        gameController = FindObjectOfType<GameController>();
    }

    public void TakeDamage(int damage)
    {
        if (isPlayer)
        {
          
            if (Time.time - lastHitTime < invulnerabilityDuration)
            { 
                Debug.Log("El jugador es invulnerable, no se aplica daño.");
                return;
            }
            health -= damage;
            Debug.Log("El jugador recibe daño.");

            if (health <= 0)
            {
                health = 0;
                Debug.Log("El jugador ha muerto.");
                gameController.currentState = GameState.GameOver;
                gameController.HandleStateChange(); 
            }
            else
            {
                Debug.Log("El jugador sigue vivo.");
            }

            lastHitTime = Time.time;
        }
        else
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Debug.Log("El enemigo ha muerto.");
            }
        }
    }
}
