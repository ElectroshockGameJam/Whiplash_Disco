using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public Button restart;
    public Button exit;
    public Text pointsText;

    // Use this for initialization
    void Start()
    {
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener(Exit);
    }

    public void SetPoints(int points)
    {
        pointsText.text = points + " points.";
    }

    private void Restart()
    {
        Time.timeScale = 1;
        ScoreManager.scoreManager.gameOver = false;
        SceneManager.LoadScene("main_scene");
        ScoreManager.scoreManager.restart();
    }

    private void Exit()
    {
        Application.Quit();
    }
}

