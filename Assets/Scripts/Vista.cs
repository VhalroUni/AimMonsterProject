using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista : MonoBehaviour
{
    
    public Camera gameCamera; 


void Update()

{

    // Convertir la posici�n del rat�n en pantalla a una posici�n en el mundo del juego
    Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

    RaycastHit hit;



    if (Physics.Raycast(ray, out hit))

    {

        // Encontrar la direcci�n desde la posici�n actual del personaje
        Vector3 targetDirection = hit.point - transform.position;



        // rote en el eje Y
        targetDirection.y = 0;



        // Aplicar la rotaci�n hacia el punto donde se encuentra el rat�n
        transform.forward = targetDirection;

    }

}

}