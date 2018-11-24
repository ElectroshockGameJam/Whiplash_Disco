using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {
    
    public void  StartGame()
    {
        SceneManager.LoadScene("main_scene");//(1);
    }

}
