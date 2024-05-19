using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public bool isPlayer;
    public float invulnerabilityDuration = 2.0f; // Duraci�n de la invulnerabilidad en segundos
    private float lastHitTime; // Tiempo del �ltimo golpe recibido
    private GameController gameController;

    private void Start()
    {
        lastHitTime = -invulnerabilityDuration; // Iniciar como si hubiera pasado el tiempo de invulnerabilidad
        gameController = FindObjectOfType<GameController>();
    }

    public void TakeDamage(int damage)
    {
        if (isPlayer)
        {
            // Si es el jugador
            if (Time.time - lastHitTime < invulnerabilityDuration)
            {
                // El jugador a�n est� en el per�odo de invulnerabilidad
                Debug.Log("El jugador es invulnerable, no se aplica da�o.");
                return;
            }

            // Si el jugador no est� en per�odo de invulnerabilidad
            health -= damage;
            Debug.Log("El jugador recibe da�o.");

            if (health <= 0)
            {
                // Si la salud llega a cero o menos, el jugador muere
                health = 0;
                Debug.Log("El jugador ha muerto.");
                gameController.currentState = GameState.GameOver;
                gameController.HandleStateChange();

                
            }
            else
            {
                // Si la salud es mayor que cero, el jugador est� vivo
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
