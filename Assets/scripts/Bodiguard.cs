using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodiguard : MonoBehaviour {

    public Collider powerUpGenerator;
    public Collider powerUp;
    public GameManager gameManager;
    public AudioSource audiosource;
    public AudioClip audioScream;

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag ("Enemy")) {
            gameManager.killPlayer();
            Destroy (collision.gameObject);
			ScoreManager.scoreManager.addCoins();
			ScoreManager.scoreManager.addPoint();
            audiosource.clip = audioScream;
            audiosource.Play();

            if ( Random.Range( 0, 6 ) == 0 ) generatePowerUp();
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
