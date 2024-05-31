using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject optionsPanel;
    public GameObject levelPanel;
    public Slider volumeSlider;


    private void Start()
    {
        mainMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        levelPanel.SetActive(false);
        volumeSlider.onValueChanged.AddListener(SetVolume);
        InitializeOptions();

    }
    private void InitializeOptions()
    {
        volumeSlider.value = AudioListener.volume;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
    public void OpenLevelMenu()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        levelPanel.SetActive(true);
    }
    public void OpenOptionsMenu()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void CloseOptionsMenu()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        levelPanel.SetActive(false);
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartNormal()
    {
        SceneManager.LoadScene("Forest");
    }

    public void StartHard()
    {
        SceneManager.LoadScene("HardMode");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
