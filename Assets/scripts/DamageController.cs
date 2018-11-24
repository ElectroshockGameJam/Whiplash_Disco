using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {
	private float life_points = 100f;
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
			life_points -= 25;
			timer = 0;

			Debug.Log( life_points );

			if( life_points <= 0 ){

			}
		}
	}


}