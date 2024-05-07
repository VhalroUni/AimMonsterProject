using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move1 : MonoBehaviour
{
    public float speed = 5f;
    public Animator animator;
    public Transform characterModel;

    void Start()
    {
        characterModel = transform.GetChild(0);
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal,0.0f, moveVertical).normalized;

        transform.Translate(movement * speed * Time.deltaTime);

        
        bool isMoving = movement.magnitude > 0.1f;
     
        if (isMoving)
        {
            animator.SetFloat("Speed", 1); 
        }
        else
        {
            animator.SetFloat("Speed", 0); 
        }



    }

}

