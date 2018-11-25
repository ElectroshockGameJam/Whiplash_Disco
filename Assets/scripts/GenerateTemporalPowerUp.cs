using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTemporalPowerUp : MonoBehaviour {

    [HideInInspector] public Collider powerUp;
    [HideInInspector] public GameManager gameManager;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag ("Player")) {
            float x = Random.Range( -10, 10 );
            float z = Random.Range( -10, 10 );
            Vector3 position = new Vector3( x, 3, z );
            Collider obj = (Collider) Instantiate ( powerUp, position, Quaternion.identity );
            obj.gameObject.GetComponent<ControllTemporalPowerUp>().gameManager = gameManager;
            Destroy( gameObject );
        }
    }
}
