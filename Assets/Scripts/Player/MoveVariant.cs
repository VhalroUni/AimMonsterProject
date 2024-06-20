using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVariant : MonoBehaviour
{
    public string HorizontalAxisName = "Horizontal";
    public string VerticalAxisName = "Vertical";
    //Velocidad en público para que en cualquier momento podamos jugar con ella.
    public float speed = 5f;
    public Animator animator;

    public float maxSpeed = 10f;
    public float acceleration = 5f;

    void Update()
    {
        //Esto nos ayuda a que la velocidad, en diagonal, no se duplique.
        Vector3 movement = new Vector3(Input.GetAxis(HorizontalAxisName), 0.0f, Input.GetAxis(VerticalAxisName)).normalized;
        transform.Translate(movement * speed * Time.deltaTime);
        animator.SetFloat("Blend", movement.magnitude != 0f ? 1f : 0f);

    }

}