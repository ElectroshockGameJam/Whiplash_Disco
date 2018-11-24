using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public Button resume;
    public Button exit;
    public Canvas canvas;

	// Use this for initialization
	void Start () {
        resume.onClick.AddListener(Resume);
        exit.onClick.AddListener(Exit);
        canvas.gameObject.SetActive(false);
	}

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            } else
            {
                Resume();
            }
            
        }    
    }

    private void Resume()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void Exit()
    {
        Application.Quit();
    }
}
