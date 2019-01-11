using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightMode : MonoBehaviour {
	public bool focus = false;
	public Transform light;
	public Transform spotLights;

	public List<Color> colorsList;
	public float time_between;
	private float timer;
	private int frameCount;

	// Use this for initialization
	void Start () {
		timer = 0;
		frameCount = 0;

	}


	// Update is called once per frame
	void Update () {
		frameCount++;

		if (focus && frameCount > 10) {
			frameCount = 0;
			StartCoroutine (changeColors ());
		}
	}



	IEnumerator changeColors(){
		if (focus) {
			float tiempo;
			int random, chIndex,count = 0;
			random = Random.Range (0, colorsList.Count);
			chIndex = Random.Range(0, spotLights.childCount);
			GameObject obj = spotLights.GetChild(chIndex).gameObject;
			obj.SetActive (true);
			obj.GetComponent<Light> ().color = colorsList [random];

			foreach (Transform spotLight in spotLights) {
				if (count != chIndex) {
					spotLight.gameObject.SetActive (false);
				}
				count++;
			}
			timer += Time.deltaTime;
			Debug.Log ("Tiempo luz: " + timer);
			if (timer >= 1) {
				timer = 0;
				stopLights ();
			}
			tiempo = Time.realtimeSinceStartup;
			yield return new WaitForSecondsRealtime (time_between);
			Debug.Log ("Entrada 1: " + (tiempo - Time.realtimeSinceStartup));
		}
	}
	public void startLights(){
		light.gameObject.SetActive (false);
		spotLights.gameObject.SetActive (true);
		focus = true;
	}

	public void stopLights(){
		light.gameObject.SetActive (true);
		spotLights.gameObject.SetActive (false);
		focus = false;
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag ("PowerDown")) {

			startLights ();
			Destroy( collision.gameObject );
		}
	}
}
