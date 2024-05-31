using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    private GameController gameStatus;
    public GameObject pausePanel;
    private SceneReloader sceneReloader;
    public Button resumeButton;
    public bool isPressed = false;
    private void Start()
    {
        pausePanel.SetActive(false);
        gameStatus = FindObjectOfType<GameController>();
        sceneReloader = FindObjectOfType<SceneReloader>();
        resumeButton.onClick.AddListener(ButtonPressed);

    }
    public void Update()
    {
        if(gameStatus.currentState == GameState.Paused)
        {
            pausePanel.SetActive(true);

        }
        else
        {
            pausePanel.SetActive(false);
        }
    }
   public void ButtonPressed()
    {
        isPressed = true;
    }
    public void RestartScene()
    {
        sceneReloader.ReloadScene();

    }
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
