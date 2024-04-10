using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speedHorizontal = 15f;
    public float speedVertical = 15f;

    // Update is called once per frame

    void Update()

    {
        // Utiliza las variables públicas en lugar de valores fijos

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speedHorizontal, 0f, 0f);
        transform.Translate(0f, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speedVertical);

    }

}

