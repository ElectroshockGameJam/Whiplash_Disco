using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start ( ) {
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKey("left") || Input.GetKey( KeyCode.A ) ){
			gameObject.transform.Translate( -speed * Time.deltaTime, 0, 0 );
		}
		if( Input.GetKey("right") || Input.GetKey( KeyCode.D ) ){
			gameObject.transform.Translate( speed * Time.deltaTime, 0, 0 );
		}
		if( Input.GetKey("up") || Input.GetKey( KeyCode.W ) ){
			gameObject.transform.Translate( 0, 0, speed * Time.deltaTime );
		}
		if( Input.GetKey("down") || Input.GetKey( KeyCode.S ) ){
			gameObject.transform.Translate( 0, 0, -speed * Time.deltaTime );
		}
	}
}
