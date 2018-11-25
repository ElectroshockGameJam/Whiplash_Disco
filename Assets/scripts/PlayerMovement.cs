using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private enum Position {FRONT, BACK, LEFT, RIGHT};
	public float speed;
	public Animator animator;
	private Position pos = Position.FRONT;

	private int changed;

    private Whip WhipScript;	

	// Use this for initialization
	void Start ( ) {
        WhipScript = GetComponentInChildren<Whip>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Time.timeScale == 0.0f)
            return;

		int rotationValue;
		changed = 0;
		if (!WhipScript.charging && !ScoreManager.scoreManager.gameOver) {
			//Code for moving inside the scene
			if (Input.GetKey (KeyCode.A) || Input.GetAxis ("Horizontal") > 0.3) {
				gameObject.transform.Translate (-speed * Time.deltaTime, 0, 0);
				changed = 1;
				animator.SetFloat ("movement", 3.0f);
			}
			if (Input.GetKey (KeyCode.D) || Input.GetAxis ("Horizontal") < -0.3) {
				gameObject.transform.Translate (speed * Time.deltaTime, 0, 0);
				changed = 1;
				animator.SetFloat ("movement", 3.0f);
			}
			if (Input.GetKey (KeyCode.W) || Input.GetAxis ("Vertical") > 0.3) {
				gameObject.transform.Translate (0, 0, speed * Time.deltaTime);
				changed = 1;
				animator.SetFloat ("movement", 3.0f);
			}
			if (Input.GetKey (KeyCode.S) || Input.GetAxis ("Vertical") < -0.3) {
				gameObject.transform.Translate (0, 0, -speed * Time.deltaTime);
				changed = 1;
				animator.SetFloat ("movement", 3.0f);
			}
		} 

		if (WhipScript.charging) {
			animator.SetBool ("charge", true);
			changed = 1;
		}
        else
        {
            animator.SetBool("charge", false);
        }

        if (changed == 0)
        {
            animator.SetFloat("movement", 0.0f);
        }

        //Code for changing the player orientation
        if ( ( Input.GetKey("up") || Input.GetAxis("Vertical_View") > 0.3 ) && pos != Position.BACK ){
            
			animator.SetInteger ("orientation", 2);

			if( pos == Position.FRONT ) rotationValue = 180;
			else if( pos == Position.RIGHT ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.BACK;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
		else if( ( Input.GetKey("down") || Input.GetAxis("Vertical_View") < -0.3 ) && pos != Position.FRONT ){
			
			animator.SetInteger ("orientation", 0);

			if( pos == Position.BACK ) rotationValue = 180;
			else if( pos == Position.LEFT ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.FRONT;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
		else if( ( Input.GetKey("left") || Input.GetAxis("Horizontal_View") > 0.3 ) && pos != Position.LEFT ){
            
			animator.SetInteger ("orientation", 3);

			if( pos == Position.RIGHT ) rotationValue = 180;
			else if( pos == Position.BACK ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.LEFT;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
		else if( ( Input.GetKey("right") || Input.GetAxis("Horizontal_View") < -0.3 ) && pos != Position.RIGHT ){
            
			animator.SetInteger ("orientation", 1);

			if( pos == Position.LEFT ) rotationValue = 180;
			else if( pos == Position.FRONT ) rotationValue = 270;
			else rotationValue = 90;
			pos = Position.RIGHT;
			gameObject.transform.GetChild(0).Rotate( Vector3.up*rotationValue );
		}
	}
}
