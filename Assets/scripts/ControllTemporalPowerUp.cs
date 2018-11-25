using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllTemporalPowerUp : MonoBehaviour {
    private float timer;
    [HideInInspector] public GameManager gameManager;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if( timer >= 8 ){
            Destroy( gameObject );
        }
		
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag ("Enemy") ) {
            Destroy (collision.gameObject);
            gameManager.killPlayer();
        }
    }
}
