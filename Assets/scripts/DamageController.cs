using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {
	private float timer = 1f;

	private void Update(){
		timer += Time.deltaTime;
	}

	private void OnTriggerEnter( Collider collision){
		updateLife( collision );
	}

	private void OnTriggerStay( Collider collision ){
		updateLife( collision );
	}

	private void updateLife( Collider collision ){
		if( collision.gameObject.CompareTag( "Enemy" ) && timer >= 1f ){
			ScoreManager.scoreManager.decreaseLifePoints();
			timer = 0;

			if( ScoreManager.scoreManager.getLifePoints() <= 0 ){

			}
		}
	}


}