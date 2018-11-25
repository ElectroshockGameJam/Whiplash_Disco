using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTemporalPowerUp : MonoBehaviour {
    [HideInInspector] public Collider powerUp;
    [HideInInspector] public GameManager gameManager;
    private bool spawned = false;
    private float timer;

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
        if (collision.gameObject.CompareTag ("Player")) {
            float x = Random.Range( -10, 10 );
            float z = Random.Range( -10, 10 );
            Vector3 position = new Vector3( x, 3, z );
            if( !spawned ){
                Collider obj = (Collider) Instantiate ( powerUp, position, Quaternion.identity );
                obj.gameObject.GetComponent<ControllTemporalPowerUp>().gameManager = gameManager;
                spawned = true;
            }
            Destroy( gameObject );
        }
    }
}
