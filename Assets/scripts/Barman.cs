using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barman : MonoBehaviour {

    private readonly int maxLevels = 4;

    public Transform canvas;
    public GameObject player;
    public Button superSpeed;
    public Text superSpeedPriceText;
    public Text superWhipPriceText;
    public Button superWhip;
    public TextMesh obrirTenda;
    private bool isInBar;

    public int superSpeedPrice;
    public float superSpeedBonus;
    private int superSpeedLevel = 1;

    public int superWhipPrice;
    public float superWhipBonus;
    private int superWhipLevel = 1;

    // Use this for initialization
    void Start () {
        canvas.gameObject.SetActive(false);
        obrirTenda.gameObject.SetActive(false);
        superSpeed.onClick.AddListener(SuperSpeed);
        superWhip.onClick.AddListener(SuperWhip);
        isInBar = false;

        superSpeedPriceText.text = superSpeedPrice.ToString();
        superWhipPriceText.text = superWhipPrice.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T) && isInBar)
        {
            obrirTenda.gameObject.SetActive(false);
            if (canvas.gameObject.activeInHierarchy == false)
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                obrirTenda.gameObject.SetActive(true);
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            obrirTenda.gameObject.SetActive(true);
            isInBar = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            obrirTenda.gameObject.SetActive(false);
            isInBar = false;
        }
    }

    private void SuperSpeed()
    {
        if (superSpeedLevel < maxLevels && ScoreManager.scoreManager.buyPowerup(superSpeedLevel * superSpeedPrice))
        {
            player.GetComponent<PlayerMovement>().speed *= superSpeedBonus;
            superSpeedLevel++;
            if (superSpeedLevel >= maxLevels)
            {
                DisableButton(superSpeed);
            }
            else
            {
                superSpeedPriceText.text = (superSpeedPrice * superSpeedLevel).ToString();
                superSpeed.GetComponentInChildren<Text>().text = "Super Velocitat x" + superSpeedLevel;
            }
        }
    }

    private void DisableButton(Button button)
    {
        button.interactable = false;
    }

    private void SuperWhip()
    {
        if (superWhipLevel < maxLevels && ScoreManager.scoreManager.buyPowerup(superWhipLevel * superWhipPrice))
        {
            Whip whip = player.GetComponentInChildren<Whip>();
            whip.maxForce *= superWhipBonus;
            whip.minForce *= superWhipBonus;
            superWhipLevel++;
            if (superWhipLevel >= maxLevels)
            {
                DisableButton(superWhip);
            } else
            {
                superWhipPriceText.text = (superWhipPrice * superWhipLevel).ToString();
                superWhip.GetComponentInChildren<Text>().text = "Super Fuet x" + superWhipLevel;
            }
        }
    }

}
