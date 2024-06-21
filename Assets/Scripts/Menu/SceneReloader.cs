using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    
    [SerializeField] private float transitionTime = 1f;

    public Animator transitionAnimator;
    

    public void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator> ();
    }


    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        //
        StartCoroutine(SceneLoad(currentSceneName));
        //

        /*SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1;
        Timer.instanciar.InicioTiempo();*/ //no fet per mi.
    }

    //
    public void LoadScene(string sceneName)
    {
        StartCoroutine(SceneLoad(sceneName));
    }

    public IEnumerator SceneLoad(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
    //

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            ReloadScene();
        }
    }


}
