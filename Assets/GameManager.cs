using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;
    public int health = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.O))
        {
            health -= 1;
            if (health <= 0)
            {
                health = 0;
            }
        }
        if (health == 0)
        {
            PauseGame();
            
        }

        if (isPaused)
        {
            if (Input.GetKeyUp(KeyCode.P))
            {
                Resumegame();
                health = 3;
            }
        }


    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    void Resumegame()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }
}
