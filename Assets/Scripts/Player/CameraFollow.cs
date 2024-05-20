using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personaje; // Que queremos que siga la camara.
    //Limites de la camara. Están en privado porque, hasta que no acabamos el juego, no se tocará.
    private float Left = -22.9f; 
    private float Right = 23f; 
    private float Up = 14.3f; 
    private float Down = -31.4f; 

    private Vector3 offset; // Distancia entre la cámara y el personaje.

    void Start()
    {
        offset = transform.position - personaje.position; // Calcula la distancia inicial entre la cámara y el personaje.
    }

    void LateUpdate()
    {
        Vector3 objetivoPosicion = personaje.position + offset; // Calcula la posición a la que la cámara debería moverse.

        // Limita la posición de la cámara para que no se mueva más allá de los límites.
        objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, Left, Right);
        objetivoPosicion.z = Mathf.Clamp(objetivoPosicion.z, Down, Up);

        transform.position = objetivoPosicion; // Mueve la cámara a la posición objetivo.
    }
}

