using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform Objective;
    public NavMeshAgent IA;

    void Start()
    {
        IA.SetDestination(Objective.position);
    }

    // Update is called once per frame
    void Update()
    {
        IA.SetDestination(Objective.position);
    }
}
