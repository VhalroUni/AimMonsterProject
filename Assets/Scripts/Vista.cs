using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista : MonoBehaviour
{
    
    public Camera gameCamera; 


void Update()

{

    // Convertir la posición del ratón en pantalla a una posición en el mundo del juego
    Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

    RaycastHit hit;



    if (Physics.Raycast(ray, out hit))

    {

        // Encontrar la dirección desde la posición actual del personaje
        Vector3 targetDirection = hit.point - transform.position;



        // rote en el eje Y
        targetDirection.y = 0;



        // Aplicar la rotación hacia el punto donde se encuentra el ratón
        transform.forward = targetDirection;

    }

}

}