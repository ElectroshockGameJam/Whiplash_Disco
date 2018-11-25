using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {

    public AudioClip[] audios;

	void Start()
    {
        StartCoroutine(playRandom());
    }

    private IEnumerator playRandom()
    {
        for (; ; ) {
            this.gameObject.GetComponent<AudioSource>().clip = audios[Random.Range(0, audios.Length)];
            this.gameObject.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(this.gameObject.GetComponent<AudioSource>().clip.length);
        }
    }
}
