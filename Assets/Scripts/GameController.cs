using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    Playing,
    Paused,
    GameOver
}


public class GameController : MonoBehaviour
{
    public GameState currentState = GameState.Playing;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar al estado pausado si no lo está, o al estado jugando si ya está pausado
            currentState = currentState == GameState.Playing ? GameState.Paused : GameState.Playing;
            HandleStateChange();
        }
    }
   public void HandleStateChange()
    {
        switch (currentState)
        {
            case GameState.Playing:
                Time.timeScale = 1;   
                break;
            case GameState.Paused:
                Time.timeScale = 0;
                break;
            case GameState.GameOver:
                Time.timeScale = 0;
                break;
        }
    }
   public GameState GetCurrentState() { return currentState; }
}
