using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   //Velocidad en público para que en cualquier momento podamos jugar con ella.
    public float speed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Esto nos ayuda a que la velocidad, en diagonal, no se duplique.
        Vector3 movement = new Vector3(moveHorizontal,0.0f, moveVertical).normalized;

        transform.Translate(movement * speed * Time.deltaTime); 

    }

}

