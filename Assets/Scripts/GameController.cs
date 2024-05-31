
using UnityEngine;
using UnityEngine.UI;


public enum GameState
{
    Playing,
    Paused,
    GameOver
}
public class GameController : MonoBehaviour
{
    public GameState currentState = GameState.Paused;
    public PauseMenuManager pauseManager;
    void Start()
    {
        Timer.instanciar.InicioTiempo();
        Time.timeScale = 1;
        pauseManager = FindObjectOfType<PauseMenuManager>();
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || pauseManager.isPressed) && !pauseManager.isDead )
        {
            currentState = currentState == GameState.Playing ? GameState.Paused : GameState.Playing; // Cambia al estado de pausa si no lo está, o al estado de juego si está pausado
            HandleStateChange();
            pauseManager.isPressed = false;
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
