using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    // Use this for initialization
    public string sceneName;


    void Start()
    {
        sceneName = "Main";
    }
    
    public void OnClick()
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log(sceneName);
    }
}
