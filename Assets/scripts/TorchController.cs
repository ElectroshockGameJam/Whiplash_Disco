using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour {
    private float timer;
    private Renderer rend;
    private bool showing;
    private float spped = 50.0f;

	// Use this for initialization
	void Start () {
        timer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate( Vector3.up * spped * Time.deltaTime );
        timer += Time.deltaTime;
        if( timer >= 6 ){
            Destroy( gameObject );
        }
    }

}
