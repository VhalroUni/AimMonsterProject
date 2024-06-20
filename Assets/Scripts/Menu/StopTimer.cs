using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTimer : MonoBehaviour
{
    private GameController gameStatus;
     void Update()
    {
        if (gameStatus.GetCurrentState() == GameState.GameOver)
        {
            Timer.instanciar.FinTiempo();       
        }
    }
}
