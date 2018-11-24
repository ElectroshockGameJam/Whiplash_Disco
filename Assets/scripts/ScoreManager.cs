using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager scoreManager;
    public Text life_pointsText;
    public Text coinsText;
    public Text pointsText;
    private int life_points = 4;
    private int coins = 0;
    private int points = 0;

    public Canvas GameOverCanvas;
    [HideInInspector] public bool gameOver = false;

	// Use this for initialization
	void Start () {
		if( scoreManager == null ){
			scoreManager = this;
			Object.DontDestroyOnLoad(this);
		}
		else{
			Destroy(gameObject);
		}
        
        life_pointsText.text = life_points + "";
		pointsText.text = points + ""; 
		coinsText.text = coins + "";
        GameOverCanvas.gameObject.SetActive(false);
    }

	public void addPoint(){
		points += 1;
		pointsText.text = points + "";
	}

	public int getPoints(){
		return points;
	}

	public void addCoins(){
		coins += Random.Range(0, 6);
        coinsText.text = coins.ToString();
	}

	public int getCoins(){
		return coins;
	}

    public bool buyPowerup(int price)
    {
        if (price < coins)
        {
            coins -= price;
            coinsText.text = coins.ToString();
            return true;
        } else
        {
            return false;
        }
    }

	public void decreaseLifePoints(){
		life_points--;
		life_pointsText.text = life_points + "";
		//Debug.Log( life_points );

        if(life_points <= 0)
        {
            gameOver = true;
            GameOverCanvas.GetComponentInChildren<GameOverMenu>().SetPoints(points);
            GameOverCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            transform.GetChild(0).gameObject.SetActive(false);
        }
	}

	public int getLifePoints(){
		return life_points;
	}
	
    public void restart()
    {
        life_points = 4;
        coins = 0;
        points = 0;

        life_pointsText.text = life_points + "";
        pointsText.text = points + "";
        coinsText.text = coins + "";
        
        GameOverCanvas.gameObject.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
