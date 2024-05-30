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

    private void Awake()
    {
        instanciar = this;
        crono.text = "00:00:00";
        timerbool = false;
    }
    void Start()
    {
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
    }

    private IEnumerator ActUpdate()
    {
        while (timerbool)
        {
            tiempoTrans += Time.deltaTime;
            tiempoCrono = TimeSpan.FromSeconds(tiempoTrans);
            string tiempoCronoStr = tiempoCrono.ToString("mm':'ss':'ff");
            crono.text = tiempoCronoStr;
            yield return null;
        }
    }
}
