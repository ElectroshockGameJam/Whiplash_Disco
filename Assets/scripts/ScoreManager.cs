using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager scoreManager;
    public Text life_pointsText;
    //public Text coinsText;
    public Text pointsText;
    private int life_points = 4;
    private int coins = 0;
    private int points = 0;

	// Use this for initialization
	void Start () {
		if( scoreManager == null ){
			scoreManager = this;
			Object.DontDestroyOnLoad(this);
		}
		else{
			Destroy(this);
		}
		life_pointsText.text = life_points + "";
		pointsText.text = points + ""; 
		//coinsText.text = coins + "";
	}

	public void decreaseLifePoints(){
		life_points--;
		life_pointsText.text = life_points + "";
		//Debug.Log( life_points );
	}

	public int getLifePoints(){
		return life_points;
	}
	
}
