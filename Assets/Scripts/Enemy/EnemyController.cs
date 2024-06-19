using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform Objective;
    public NavMeshAgent IA;
    public int damage;
    public float delay = 6.0f;
    public float lastAttack;
    private GameController currentState;

    public int enemyIndex;

    // Variable p�blica para el prefab de part�culas
    public GameObject deathParticles;

    void Start()
    {
        IA.SetDestination(Objective.position);
        currentState = FindObjectOfType<GameController>();
    }
    void Update()
    {
        IA.SetDestination(Objective.position);
    }
    private void OnMouseDown() //Funci�n que se activa cuando el jugador clica encima de un enemigo
    {
        Health enemyHealth = GetComponent<Health>();

        if (currentState.GetCurrentState() == GameState.Paused || currentState.GetCurrentState() == GameState.GameOver)
        {
            return;
        }
        enemyHealth.TakeDamage(1);
        if (enemyHealth.health <= 0)
        {
            SoundManager.instance.PlayEnemyDeathSound(enemyIndex);

            // Instanciar part�culas de muerte
            if (deathParticles != null)
            {
                GameObject particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
                Destroy(particles, 3.0f); // Destruir las part�culas despu�s de 1 segundo
            }

            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) //Cuando el enemigo tenga una colisi�n se activa esta funci�n 
    {
        if (!collision.gameObject.CompareTag("Player")) //Verifica si es el player con quien colisiona el enemigo, si no es sale de la funci�n
        {
            return;
        }
        Health OtherHealth = collision.gameObject.GetComponent<Health>();
        if (OtherHealth != null)
        {
            OtherHealth.TakeDamage(damage);
        }
    }
}
