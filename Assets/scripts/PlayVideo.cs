using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideo : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    private double actualTime = 0.0f;

    // Use this for initialization
    void Start()
    {
        rawImage.enabled = false;
    }

    public void StartVideo()
    {
        rawImage.enabled = true;
        videoPlayer.time = actualTime;
        StartCoroutine(PlayVid());
    }

    public void PauseVideo()
    {
        actualTime = videoPlayer.time;
        if (actualTime >= 250)
        {
            actualTime = 0.0;
        }
        StopAllCoroutines();
        rawImage.enabled = false;
    }

    private IEnumerator PlayVid()
    {
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.Play();
        audioSource.Play();
    }
}
