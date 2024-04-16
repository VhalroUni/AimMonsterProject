using UnityEngine;

public class LimitarMovimientoCamara : MonoBehaviour
{
    public Transform personaje; // Referencia al transform del personaje principal
    //public Transform limiteCamaras;
    public float x1 = -28.12f;
    public float x2 = 17.78f;
    public float z1 = 54.52f;
    public float z2 = 8.82f;
   
    private Vector3 offset; // Distancia entre la c�mara y el personaje

    void Start()
    {
        offset = transform.position - personaje.position; // Calcula la distancia inicial entre la c�mara y el personaje
    }

    void LateUpdate()
    {
        Vector3 objetivoPosicion = personaje.position + offset; // Calcula la posici�n a la que la c�mara deber�a moverse

        // Limita la posici�n de la c�mara para que no se mueva m�s all� de los l�mites
        objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, x1, x2);
        objetivoPosicion.z = Mathf.Clamp(objetivoPosicion.z, z2, z1);

        transform.position = objetivoPosicion; // Mueve la c�mara a la posici�n objetivo
    }
}

