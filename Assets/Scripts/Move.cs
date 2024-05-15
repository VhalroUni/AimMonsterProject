using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public string HorizontalAxisName = "Horizontal";
    public string VerticalAxisName = "Vertical";
    // Parámetros de movimiento.
    public float initialAcceleration = 70f;
    public float maxSpeed = 15f;
    public float impulse = 30f;
    public float deceleration = 50f;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public Rigidbody rb;
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis(HorizontalAxisName), 0.0f, Input.GetAxis(VerticalAxisName));
        input = Vector3.ClampMagnitude(input, 1f); // Limitar la magnitud del vector de entrada a 1 para evitar la aceleración excesiva en diagonal.

        // Calcular la aceleración.
        Vector3 accelerationVector = input * initialAcceleration;

        // Calcular la velocidad.
        velocity += accelerationVector * Time.fixedDeltaTime;

        // Limitar la velocidad máxima.
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Aplicar impulso para permitir cambios de dirección suaves.
        if (input.magnitude != 0)
        {
            Vector3 impulseVector = input * impulse;
            velocity += impulseVector * Time.fixedDeltaTime;
        }

        // Aplicar deceleración si no se está presionando ninguna tecla de movimiento.
        if (input.magnitude == 0 && velocity.magnitude > 0)
        {
            float decelerationAmount = deceleration * Time.fixedDeltaTime;
            velocity -= velocity.normalized * decelerationAmount;
            if (velocity.magnitude < 0.1f)
            {
                velocity = Vector3.zero;
            }
        }

        // Mover el objeto.
        rb.position += (velocity * Time.fixedDeltaTime);

        // Establecer la animación.
        animator.SetFloat("Blend", velocity.magnitude / maxSpeed);
    }
}

