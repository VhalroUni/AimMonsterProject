using UnityEngine;

public class LimitarMovimientoCamara : MonoBehaviour
{
    public Transform personaje; // Referencia al transform del personaje principal
    public Transform limiteCamaras; // Referencia al transform del objeto que marca los límites de la cámara

    private Vector3 offset; // Distancia entre la cámara y el personaje

    void Start()
    {
        offset = transform.position - personaje.position; // Calcula la distancia inicial entre la cámara y el personaje
    }

    void LateUpdate()
    {
        Vector3 objetivoPosicion = personaje.position + offset; // Calcula la posición a la que la cámara debería moverse

        // Limita la posición de la cámara para que no se mueva más allá de los límites
        objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, limiteCamaras.position.x - offset.x, limiteCamaras.position.x + offset.x);
        objetivoPosicion.z = Mathf.Clamp(objetivoPosicion.z, limiteCamaras.position.z - offset.z, limiteCamaras.position.z + offset.z);

        transform.position = objetivoPosicion; // Mueve la cámara a la posición objetivo
    }
}

