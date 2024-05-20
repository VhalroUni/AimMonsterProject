using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPosition : MonoBehaviour
{
    //Aqu� asignamos la c�mara.
    public Camera gameCamera;
    public GameController gameController;
    void Update()
    {
        if (gameController.GetCurrentState() != GameState.Playing)
        {
          
            return;
        }
        // Calcular las coordenadas del rat�n en base a la variable que hayamos designado.
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            // Encontrar la direcci�n desde la posici�n actual del personaje.
            Vector3 targetDirection = hit.point - transform.position;
            // Rotamos solo en el eje Y. En el eje X no hace falta porque la vista es picada.
            targetDirection.y = 0;

            // Aplicamos la rotaci�n hacia el punto donde se encuentra el rat�n.
            transform.forward = targetDirection;
        }
    }
}