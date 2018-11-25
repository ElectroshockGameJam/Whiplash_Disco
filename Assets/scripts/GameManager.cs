using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text waveText;
    public Transform[] respawnPsitions;
    public Rigidbody[] enemys;


    public Transform Player;
    public float speed;
    public float factor;

    public float countdown;

    private int actualLevel;
    private enum WaveStatus { prepare, preparing, spawn, spawning, waitCompletion };
    private WaveStatus waveState;
    private int enemiesToEndWave, counterEnemys;

    private float diff;
    // Use this for initialization
    void Start()
    {
        diff = 0;
        counterEnemys = 0;
        actualLevel = 1;
        waveText.text = "";
        waveState = WaveStatus.spawn;
    }

    // Update is called once per frame
    void Update()
    {
        switch (waveState)
        {
            case WaveStatus.prepare:
                waveText.text = "Prepare for the next wave...";
                StartCoroutine( PrepareWave() );
                actualLevel++;
                waveState = WaveStatus.preparing;
                break;
            case WaveStatus.preparing:
                break;
            case WaveStatus.spawn:
                StartCoroutine( SpawnWave() );
                waveState = WaveStatus.spawning;
                break;
            case WaveStatus.spawning:
                break;
            case WaveStatus.waitCompletion:
                if (enemiesToEndWave <= 0)
                {
                    ScoreManager.scoreManager.addCoins();
                    ScoreManager.scoreManager.addPoint();
                    waveState = WaveStatus.prepare;
                }
                break;
        }
    }

    private IEnumerator PrepareWave()
    {
        yield return new WaitForSeconds(2.0f);
        waveText.text = "";
        yield return new WaitForSeconds(3.0f);
        int i = 3;
        while (i > 0)
        {
            waveText.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
            i--;
        }
        waveText.text = "";
        waveState = WaveStatus.spawn;
    }

    private IEnumerator SpawnWave()
    {
        enemiesToEndWave = actualLevel * 2 + 8;
        int enemiesToSpawn = enemiesToEndWave;
        int spawned = 0;
        while (spawned < enemiesToSpawn) { 
            Debug.Log("Create enemy");

            counterEnemys++;

            Debug.Log("New Diff: " + diff);

            int transfInd = Random.Range(0, respawnPsitions.Length);
            int objectInd = Random.Range(0, enemys.Length);

            Rigidbody obj = (Rigidbody)Instantiate(enemys[objectInd], respawnPsitions[transfInd].position, Quaternion.identity);
            obj.gameObject.GetComponent<MoveTo>().goal = Player;
            obj.isKinematic = true;

            obj.gameObject.GetComponent<EnemyAnimation>().player = Player;
		
            obj.name = " " + Time.deltaTime;

            obj.gameObject.SetActive(true);
            yield return new WaitForSeconds( speed );
            spawned++;
        }

        waveState = WaveStatus.waitCompletion;
    }

    public void killPlayer()
    {
        enemiesToEndWave--;
    }
}
