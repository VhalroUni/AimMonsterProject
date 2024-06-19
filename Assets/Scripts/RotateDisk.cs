using UnityEngine;

public class RotateDisk : MonoBehaviour
{
    // Variable pública para ajustar la velocidad de rotación desde el inspector
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rota el objeto en el eje Z a una velocidad constante
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
