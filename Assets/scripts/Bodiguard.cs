using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodiguard : MonoBehaviour {

    public Collider powerUpGenerator;
    public Collider powerUp;
    public GameManager gameManager;
    public AudioSource audiosource;
    public AudioClip audioScream;
	public Animator animator;
	private float time;

	void Update(){
		time += Time.timeScale;
		if (time >= 3) {
			animator.SetBool ("throw", false);
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag ("Enemy")) {
			time = 0;
			animator.SetBool ("throw", true);

            gameManager.killPlayer();
            Destroy (collision.gameObject);
			ScoreManager.scoreManager.addCoins();
			ScoreManager.scoreManager.addPoint();
            int random = Random.Range( 0, 6 );
            Debug.Log( random );
            if ( random == 0 ) generatePowerUp();
            audiosource.clip = audioScream;
            audiosource.Play();
		}
    }

    private void generatePowerUp(){
        float x = Random.Range( -10, 10 );
        float z = Random.Range( -10, 10 );
        Vector3 position = new Vector3( x, 4, z );
        Collider obj = (Collider) Instantiate ( powerUpGenerator, position, Quaternion.identity );
        obj.gameObject.GetComponent<GenerateTemporalPowerUp>().powerUp = powerUp;
        obj.gameObject.GetComponent<GenerateTemporalPowerUp>().gameManager = gameManager;
    }

}
