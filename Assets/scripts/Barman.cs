using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barman : MonoBehaviour {

    private readonly int maxLevels = 4;

    public GameManager gameManager;
    public Transform canvas;
    public GameObject player;
    public Button superSpeed;
    public Text superSpeedPriceText;
    public Text superWhipPriceText;
    public Button superWhip;
    public TextMesh obrirTenda;
    public Button megaWhip;
    public Text megaWhipPriceText;
    public Button buyLife;
    public Text buyLifeText;
    public Button exitButton;
    public Text surpriseText;
    public Button surpriseButton;
    private bool isInBar;

    public int superSpeedPrice;
    public float superSpeedBonus;
    private int superSpeedLevel = 1;

    public int superWhipPrice;
    public float superWhipBonus;
    private int superWhipLevel = 1;

    public int megaWhipPrice;
    private int megaWhipLevel = 1;

    public int lifePrice;

    public int surprisePrice;

    public static bool storeOpen = false;

    // Use this for initialization
    void Start () {
        canvas.gameObject.SetActive(false);
        obrirTenda.gameObject.SetActive(false);
        superSpeed.onClick.AddListener(SuperSpeed);
        superWhip.onClick.AddListener(SuperWhip);
        megaWhip.onClick.AddListener(MegaWhip);
        buyLife.onClick.AddListener(BuyLife);
        exitButton.onClick.AddListener(ExitStore);
        surpriseButton.onClick.AddListener(BuySurprise);    
        isInBar = false;

        superSpeedPriceText.text = superSpeedPrice.ToString();
        superWhipPriceText.text = superWhipPrice.ToString();
        megaWhipPriceText.text = megaWhipPrice.ToString();
        buyLifeText.text = buyLife.ToString();
        surpriseText.text = surprisePrice.ToString();
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
                storeOpen = true;
            }
            else
            {
                ExitStore();
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

    private void BuySurprise()
    {
        if (ScoreManager.scoreManager.buyPowerup(surprisePrice))
        {
            gameManager.speed = 0.0f;
            DisableButton(surpriseButton);
            
        }
    }

    private void ExitStore()
    {
        storeOpen = false;
        obrirTenda.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void BuyLife()
    {
        if (ScoreManager.scoreManager.buyPowerup(lifePrice))
        {
            ScoreManager.scoreManager.addLife();
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
                superSpeed.GetComponentInChildren<Text>().text = "Super Velocity " + superSpeedLevel;
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
                superWhip.GetComponentInChildren<Text>().text = "Super Whip " + superWhipLevel;
            }
        }
    }

    private void MegaWhip()
    {
        if (megaWhipLevel < maxLevels && ScoreManager.scoreManager.buyPowerup(megaWhipLevel * megaWhipPrice))
        {
            CapsuleCollider capsule = player.GetComponentInChildren<CapsuleCollider>();
            capsule.height += megaWhipLevel;
            Vector3 center = new Vector3(capsule.center.x, capsule.center.y, -(capsule.height / 2));
            capsule.center = center;
            megaWhipLevel++;
            if (megaWhipLevel >= maxLevels)
            {
                DisableButton(megaWhip);
            }
            else
            {
                megaWhipPriceText.text = (megaWhipPrice * megaWhipLevel).ToString();
                megaWhip.GetComponentInChildren<Text>().text = "Mega Whip " + megaWhipLevel;
            }
        }
    }

}
