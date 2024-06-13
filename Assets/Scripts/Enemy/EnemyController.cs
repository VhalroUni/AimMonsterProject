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

    void Start()
    {
        IA.SetDestination(Objective.position);
        currentState = FindObjectOfType<GameController>();
    }
    void Update()
    {
        IA.SetDestination(Objective.position);
    }
    private void OnMouseDown() //Función que se activa cuando el jugador clica encima de un enemigo
    {
        Health enemyHealth = GetComponent<Health>();

        if (currentState.GetCurrentState() == GameState.Paused || currentState.GetCurrentState() == GameState.GameOver) 
        {
            return;
        }
        enemyHealth.TakeDamage(1);
        if (enemyHealth.health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision) //Cuando el enemigo tenga una colisión se activa esta función 
    {
        if (!collision.gameObject.CompareTag("Player")) //Verifica si es el player con quien colisiona el enemigo, si no es sale de la función
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
