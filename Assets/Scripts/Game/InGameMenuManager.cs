using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    private GameController gameStatus;
    public GameObject pausePanel;
    public Button resumeButton;
    public bool isPressed = false;
    public GameObject deathMenu;
    public bool isDead = false;

    private void Start()
    {
        pausePanel.SetActive(false);
        deathMenu.SetActive(false);
        gameStatus = FindObjectOfType<GameController>();
        resumeButton.onClick.AddListener(ButtonPressed);

    }
    public void Update()
    {
        if(gameStatus.currentState == GameState.Paused && !isDead)
        {
            pausePanel.SetActive(true);

        }
        else
        {
            pausePanel.SetActive(false);
            
        }
    }
   public void ShowDeathMenu()
    {
        IsDead();
        deathMenu.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void IsDead()
    {
        isDead = true;
    }
   public void ButtonPressed()
    {
        isPressed = true;
    }
    public void Exit()
    {
        gameStatus.HandleStateChange();
        SceneManager.LoadScene("MainMenu");
    }
}
