using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personaje; // Referencia al transform del personaje principal
    //public Transform limiteCamaras
    private float Left = -22.9f; //Izquierda
    private float Right = 23f; //derecha
    private float Up = 14.3f; //arriba
    private float Down = -31.4f; //abajo

    private Vector3 offset; // Distancia entre la cámara y el personaje

    void Start()
    {
        offset = transform.position - personaje.position; // Calcula la distancia inicial entre la cámara y el personaje
    }

    void LateUpdate()
    {
        Vector3 objetivoPosicion = personaje.position + offset; // Calcula la posición a la que la cámara debería moverse

        // Limita la posición de la cámara para que no se mueva más allá de los límites
        objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, Left, Right);
        objetivoPosicion.z = Mathf.Clamp(objetivoPosicion.z, Down, Up);

        transform.position = objetivoPosicion; // Mueve la cámara a la posición objetivo
    }
}

