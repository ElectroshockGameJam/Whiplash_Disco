using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barman : MonoBehaviour {

    public Transform canvas;
    public GameObject player;
    public Button superSpeed;
    public Button superWhip;

    // Use this for initialization
    void Start () {
        canvas.gameObject.SetActive(false);
        superSpeed.onClick.AddListener(SuperSpeed);
        superWhip.onClick.AddListener(SuperWhip);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T))
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}

    private void SuperSpeed()
    {
        player.GetComponent<PlayerMovement>().speed *= 2;
    }

    private void SuperWhip()
    {
        Whip whip = player.GetComponentInChildren<Whip>();
        whip.maxForce *= 2;
        whip.minForce *= 2;
    }
}
