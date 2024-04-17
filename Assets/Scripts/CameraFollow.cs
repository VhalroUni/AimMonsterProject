using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform personaje; // Referencia al transform del personaje principal
    //public Transform limiteCamaras
    private float Left = -22.9f; //Izquierda
    private float Right = 23f; //derecha
    private float Up = 14.3f; //arriba
    private float Down = -31.4f; //abajo

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

