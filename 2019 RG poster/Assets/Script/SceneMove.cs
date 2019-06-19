using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public string After;

    public void Changn()
    {
        SceneManager.LoadScene(After/*, LoadSceneMode.Additive*/);
        //SceneManager.UnloadSceneAsync(Before);
    }
    public void Off()
    {
        Application.Quit();
    }
}
