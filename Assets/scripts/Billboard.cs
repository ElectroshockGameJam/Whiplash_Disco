using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {

    public Transform target;

    int timer = 10;

	// Update is called once per frame
	void FixedUpdate () {
        timer--;
        if(timer <= 0)
        {
            transform.LookAt(target);
        }
	}
}
