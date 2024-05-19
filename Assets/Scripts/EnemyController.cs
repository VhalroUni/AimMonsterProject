using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
    private void OnMouseDown()
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
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
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
