﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public Transform[] respawnPsitions;
	public Rigidbody [] enemys;


    public Transform Player;
	public float speed;
	public float factor;

	public float countdown;

	private float  diff, counterEnemys;
	// Use this for initialization
	void Start () {
		
		diff = countdown;
		counterEnemys = 0;
	}

	// Update is called once per frame
	void Update () {
		diff -= Time.deltaTime ;

		//Debug.Log ("Countdown: " + diff);

		if ((int)diff <= 0) {
			
			Debug.Log ("Create enemy");

			counterEnemys++;

			countdown *= 0.95f;
			diff = countdown;

			Debug.Log ("New Diff: " + diff);

			int transfInd = Random.Range(0, respawnPsitions.Length);
			int objectInd = Random.Range(0, enemys.Length);

			Rigidbody obj = (Rigidbody) Instantiate (enemys[objectInd], respawnPsitions [transfInd].position, Quaternion.identity);
            obj.gameObject.GetComponent<MoveTo>().goal = Player;
            obj.isKinematic = true;
		

			obj.name = " "+Time.deltaTime;

			obj.gameObject.SetActive(true);
				
		

		}
	}
}