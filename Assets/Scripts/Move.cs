using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{   //Velocidad en público para que en cualquier momento podamos jugar con ella.
    public float speed = 5f;
    public string HorizontalInputAxisName = "Horizontal";
    public string VerticalInputAxisName = "Vertical";
    void Update()
    {
        //Esto nos ayuda a que la velocidad, en diagonal, no se duplique.
        Vector3 movement = new Vector3(Input.GetAxis(HorizontalInputAxisName),0.0f, Input.GetAxis(VerticalInputAxisName)).normalized;
        transform.Translate(movement * speed * Time.deltaTime); 

    }

}

