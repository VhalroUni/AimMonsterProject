using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneReloader : MonoBehaviour
{

    [SerializeField] private float transitionTime = 1f;

    public Animator transitionAnimator;

    public void ReloadScene()
    {
        //
        Time.timeScale = 1;
        LoadScene(SceneManager.GetActiveScene().name);
        //
    }

    //
    public void LoadScene(string sceneName)
    {
        transitionAnimator.SetTrigger("StartTransition");
        StartCoroutine(SceneLoad(sceneName));
    }

    public IEnumerator SceneLoad(string sceneName)
    {
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