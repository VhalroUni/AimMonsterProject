using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

        if (health == 0)
        {
            isPaused = true;
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (isPaused)
            {
                Resumegame();
                health = 3;
            }
            else
            {
                PauseGame();
            }
        }


    }
    void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            health = 0;
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedMonster"))
        {
            TakeDamage();
        }
    }
}
