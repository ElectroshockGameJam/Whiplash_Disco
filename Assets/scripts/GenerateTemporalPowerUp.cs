using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTemporalPowerUp : MonoBehaviour {

    [HideInInspector] public Collider powerUp;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag ("Player")) {
            float x = Random.Range( -10, 10 );
            float z = Random.Range( -10, 10 );
            Vector3 position = new Vector3( x, 3, z );
            Instantiate ( powerUp, position, Quaternion.identity );
            Destroy( gameObject );
        }
    }
}
