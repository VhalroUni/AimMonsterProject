using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int health;
    public bool isPlayer;
    public float invulnerabilityDuration = 2.0f; 
    private float lastHit; // Variable que define cuando fue recibido el último golpe
    private GameController gameController;
    public ParticleSystem butterflies;
    private ParticleSystem.Particle[] particles;


    private void Start()
    {
        lastHit = -invulnerabilityDuration; 
        gameController = FindObjectOfType<GameController>();
        particles = new ParticleSystem.Particle[butterflies.main.maxParticles];
        butterflies.Emit(maxHealth);
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

    void UpdateButterflies()
    {
        int numParticles = butterflies.GetParticles(particles);
        for(int i = 0; i< numParticles; i++)
        {
            if (i>= health)
            {
                particles[i].remainingLifetime = 0;
            }
        }
        butterflies.SetParticles(particles, numParticles);  
    }
}
