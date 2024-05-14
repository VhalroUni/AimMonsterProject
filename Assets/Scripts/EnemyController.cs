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

    void Update()
    {
        IA.SetDestination(Objective.position);
    }

    public int clicksNeeded = 1; // núm de clicks necessaris, depen de l'enemic posarem més o menys
    public int currentClicks = 0;  // clicks actuals 

    void OnMouseDown()
    {
        currentClicks++;

        if (currentClicks >= clicksNeeded)  // comprovem si s'ha arribat als clicks necessaris.
        {
            Destroy(gameObject);  // destrueix a l'objecte al que li fas click. 
        }
    }

}
