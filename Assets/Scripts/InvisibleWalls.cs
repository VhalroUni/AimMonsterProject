using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{
    public Transform personaje; //Que queremos que siga la camara.
    //Limites del mapa. Están en público para seguir perfeccionandolos con facilidad.
    public float Left = -34.98f; 
    public float Right = 35.03f; 
    public float Up = 24.81f; 
    public float Down = -41.77f;

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
