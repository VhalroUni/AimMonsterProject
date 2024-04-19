using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWalls : MonoBehaviour
{
    public Transform personaje; //Que queremos que siga la camara.
    //Limites del mapa. Est�n en p�blico para seguir perfeccionandolos con facilidad.
    public float Left = -34.98f; 
    public float Right = 35.03f; 
    public float Up = 24.81f; 
    public float Down = -41.77f;

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
