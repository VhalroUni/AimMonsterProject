using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Playing,
    Paused
}


public class GameController : MonoBehaviour
{
    private GameState currentState = GameState.Playing;

    void Update()
    {
        // Verificar si se presiona la tecla de escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar al estado pausado si no lo est�, o al estado jugando si ya est� pausado
            currentState = currentState == GameState.Playing ? GameState.Paused : GameState.Playing;

            // Llamar a la funci�n para manejar el cambio de estado
            HandleStateChange();
        }
    }

    void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1; // Reanudar el tiempo
                // Aqu� puedes agregar cualquier otra l�gica espec�fica para cuando el juego est� en estado de juego
                break;
            case GameState.Paused:
                Time.timeScale = 0; // Pausar el tiempo
                // Aqu� puedes agregar cualquier otra l�gica espec�fica para cuando el juego est� en estado pausado
                break;
        }
    }
}
