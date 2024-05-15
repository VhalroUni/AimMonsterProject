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
            // Cambiar al estado pausado si no lo está, o al estado jugando si ya está pausado
            currentState = currentState == GameState.Playing ? GameState.Paused : GameState.Playing;

            // Llamar a la función para manejar el cambio de estado
            HandleStateChange();
        }
    }

    void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1; // Reanudar el tiempo
                // Aquí puedes agregar cualquier otra lógica específica para cuando el juego esté en estado de juego
                break;
            case GameState.Paused:
                Time.timeScale = 0; // Pausar el tiempo
                // Aquí puedes agregar cualquier otra lógica específica para cuando el juego esté en estado pausado
                break;
        }
    }
}
