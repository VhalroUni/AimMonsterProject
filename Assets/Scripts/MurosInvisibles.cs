using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurosInvisibles : MonoBehaviour
{
    public Transform personaje; // Referencia al transform del personaje principal
    //public Transform limiteCamaras
    public float Left = -37.69f; //Izquierda
    public float Right = 37.67f; //derecha
    public float Up = 28.99f; //arriba
    public float Down = -45.58f; //abajo

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
