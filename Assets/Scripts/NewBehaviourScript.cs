using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;


    private void OnCollisionEnter(Collision collision)
    {
        Health OtherHealth = collision.gameObject.GetComponent<Health>();

        if (OtherHealth != null)
        {
            OtherHealth.TakeDamage(damage);
        }
    }
}
