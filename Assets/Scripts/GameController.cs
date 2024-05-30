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
    
    void Start()
    {
        Timer.instanciar.InicioTiempo();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            currentState = currentState == GameState.Playing ? GameState.Paused : GameState.Playing; // Cambia al estado de pausa si no lo está, o al estado de juego si está pausado
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
