using UnityEngine;

public class LimitarMovimientoCamara : MonoBehaviour
{
    public Transform personaje; // Referencia al transform del personaje principal
    public Transform limiteCamaras; // Referencia al transform del objeto que marca los l�mites de la c�mara

    private Vector3 offset; // Distancia entre la c�mara y el personaje

    void Start()
    {
        offset = transform.position - personaje.position; // Calcula la distancia inicial entre la c�mara y el personaje
    }

    void LateUpdate()
    {
        Vector3 objetivoPosicion = personaje.position + offset; // Calcula la posici�n a la que la c�mara deber�a moverse

        // Limita la posici�n de la c�mara para que no se mueva m�s all� de los l�mites
        objetivoPosicion.x = Mathf.Clamp(objetivoPosicion.x, limiteCamaras.position.x - offset.x, limiteCamaras.position.x + offset.x);
        objetivoPosicion.z = Mathf.Clamp(objetivoPosicion.z, limiteCamaras.position.z - offset.z, limiteCamaras.position.z + offset.z);

        transform.position = objetivoPosicion; // Mueve la c�mara a la posici�n objetivo
    }
}

