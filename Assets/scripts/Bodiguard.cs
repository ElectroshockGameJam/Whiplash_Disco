using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodiguard : MonoBehaviour {

    public GameManager gameManager;

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag ("Enemy")) {
            gameManager.killPlayer();
            Destroy (collision.gameObject);
			ScoreManager.scoreManager.addCoins();
			ScoreManager.scoreManager.addPoint();
		}
	}

}
