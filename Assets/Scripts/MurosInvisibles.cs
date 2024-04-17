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

    private Vector3 offset; // Distancia entre la c�mara y el personaje

    void Start()
    {
        offset = transform.position - personaje.position; // Calcula la distancia inicial entre la c�mara y el personaje
    }

    void LateUpdate()
    {
        Vector3 objetivoPosicion = personaje.position + offset; // Calcula la posici�n a la que la c�mara deber�a moverse

        // Limita la posici�n de la c�mara para que no se mueva m�s all� de los l�mites
        objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, Left, Right);
        objetivoPosicion.z = Mathf.Clamp(objetivoPosicion.z, Down, Up);

        transform.position = objetivoPosicion; // Mueve la c�mara a la posici�n objetivo
    }
}
