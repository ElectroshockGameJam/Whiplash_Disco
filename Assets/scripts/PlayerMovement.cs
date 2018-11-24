using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private enum Position {FRONT, BACK, LEFT, RIGHT};
	public float speed;
	private Position pos = Position.FRONT;
	

	// Use this for initialization
	void Start ( ) {
	}
	
	// Update is called once per frame
	void Update () {
		int rotationValue;

		//Code for moving inside the scene
		if( Input.GetKey( KeyCode.A ) ){
			gameObject.transform.Translate( -speed * Time.deltaTime, 0, 0 );
		}
		if( Input.GetKey( KeyCode.D ) ){
			gameObject.transform.Translate( speed * Time.deltaTime, 0, 0 );
		}
		if( Input.GetKey( KeyCode.W ) ){
			gameObject.transform.Translate( 0, 0, speed * Time.deltaTime );
		}
		if( Input.GetKey( KeyCode.S ) ){
			gameObject.transform.Translate( 0, 0, -speed * Time.deltaTime );
		}

		//Code for changing the player orientation
		if( Input.GetKey("up") && pos != Position.BACK ){
			if( pos == Position.FRONT ) rotationValue = 180;
			else if( pos == Position.RIGHT ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.BACK;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
		else if( Input.GetKey("down") && pos != Position.FRONT ){
			if( pos == Position.BACK ) rotationValue = 180;
			else if( pos == Position.LEFT ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.FRONT;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
		else if( Input.GetKey("left") && pos != Position.LEFT ){
			if( pos == Position.RIGHT ) rotationValue = 180;
			else if( pos == Position.BACK ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.LEFT;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
		else if( Input.GetKey("right") && pos != Position.RIGHT ){
			if( pos == Position.LEFT ) rotationValue = 180;
			else if( pos == Position.FRONT ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.RIGHT;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
	}
}
