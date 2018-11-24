using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoLight : MonoBehaviour {

    public List<Color> colorsList;

    float timer = 60.0f / 175.0f;
    float countdown = 0.0f;
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;

        if(countdown <= 0.0f)
        {
            int random = Random.Range(0, colorsList.Count);
            GetComponent<Light>().color = colorsList[random];

            countdown = timer;
        }
	}
}
