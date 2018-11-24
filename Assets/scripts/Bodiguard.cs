using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bodiguard : MonoBehaviour {

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag ("Enemy")) {
			Destroy (collision.gameObject);
		}
	}

}
