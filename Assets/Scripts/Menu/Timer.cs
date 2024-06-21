using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instanciar;
    public Text crono;
    private TimeSpan tiempoCrono;
    private bool timerbool;
    private float tiempoTrans;
    public ScoreManager scoreManager;

    private void Awake()
    {
        instanciar = this;
        crono.text = "00:00:00";
        timerbool = false;
    }
    void Start()
    {
        //scoreManager = FindObjectOfType<ScoreManager>();
        InicioTiempo();
    }

    public void InicioTiempo()
    {
        timerbool = true;
        tiempoTrans = 0f;
        StartCoroutine(ActUpdate());
    }
     
    public void FinTiempo()
    {
        timerbool = false;
        scoreManager.SetScore(tiempoTrans);
    }

    private IEnumerator ActUpdate()
    {
        while (timerbool)
        {
            tiempoTrans += Time.deltaTime;
            tiempoCrono = TimeSpan.FromSeconds(tiempoTrans);
            string tiempoCronoStr = tiempoCrono.ToString("mm':'ss':'ff");
            crono.text = tiempoCronoStr;
            scoreManager.SetScore(tiempoTrans);
            yield return null;
        }
    }
}
