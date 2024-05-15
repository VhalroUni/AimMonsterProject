using JetBrains.Rider.Unity.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public string HorizontalAxisName = "Horizontal";
    public string VerticalAxisName = "Vertical";
    // Par�metros de movimiento.
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
        input = Vector3.ClampMagnitude(input, 1f); // Limitar la magnitud del vector de entrada a 1 para evitar la aceleraci�n excesiva en diagonal.

        // Calcular la aceleraci�n.
        Vector3 accelerationVector = input * initialAcceleration;

        // Calcular la velocidad.
        velocity += accelerationVector * Time.fixedDeltaTime;

        // Limitar la velocidad m�xima.
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        // Aplicar impulso para permitir cambios de direcci�n suaves.
        if (input.magnitude != 0)
        {
            Vector3 impulseVector = input * impulse;
            velocity += impulseVector * Time.fixedDeltaTime;
        }

        // Aplicar deceleraci�n si no se est� presionando ninguna tecla de movimiento.
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

        // Establecer la animaci�n.
        animator.SetFloat("Blend", velocity.magnitude / maxSpeed);
    }
}

