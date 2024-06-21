using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameController gameStatus;
    public GameObject pausePanel;
    public GameObject optionsPanel;
    public Button resumeButton;
    public bool isPressed = false;
    public GameObject deathMenu;
    public bool isDead = false;
    private bool isoptionsPanel;
    public Slider volumeSlider;
    public GameObject[] pauseItems;


    private void Start()
    {
        pausePanel.SetActive(false);
        deathMenu.SetActive(false);
        optionsPanel.SetActive(false);
        resumeButton.onClick.AddListener(ButtonPressed);
        volumeSlider.onValueChanged.AddListener(SetVolume);

    }
    public void Update()
    {
        if(gameStatus.currentState == GameState.Paused && !isDead)
        {
            pausePanel.SetActive(true);
            if (!isoptionsPanel)
            {
                foreach (GameObject item in pauseItems)
                {
                    item.SetActive(true);
                }
            }
        }
        else
        {
            pausePanel.SetActive(false);
            foreach (GameObject item in pauseItems)
            {
                item.SetActive(false);
            }
        }
    }
    private void InitializeOptions()
    {
        volumeSlider.value = AudioListener.volume;
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    public void ShowPauseMenu()
    {
        deathMenu.SetActive(false);
        optionsPanel.SetActive(false);
        pausePanel.SetActive(true);
        isoptionsPanel = false;

        foreach (GameObject item in pauseItems)
        {
            item.SetActive(true);
        }
    }
   public void ShowDeathMenu()
    {
        IsDead();
        deathMenu.SetActive(true);
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
        isoptionsPanel = false;
    }
    public void ShowOptionsMenu()
    {
        deathMenu.SetActive(false);
        optionsPanel.SetActive(true);
        isoptionsPanel = true;
        foreach (GameObject item in pauseItems)
        {
            item.SetActive(false);
        }
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
