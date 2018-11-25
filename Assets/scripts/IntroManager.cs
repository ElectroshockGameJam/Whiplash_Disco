using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

    public GameObject LoadingCanvas;
    public GameObject MenuCanvas;

    private void Start()
    {
        LoadingCanvas.SetActive(false);
    }

    public void  StartGame()
    {
        LoadingCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
        SceneManager.LoadScene("main_scene");//(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
