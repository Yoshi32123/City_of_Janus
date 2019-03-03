using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneloader : MonoBehaviour {

    private GameObject player;

    public bool playerChoice; //wether or not player get an option if the 
    public string nextScene;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("tempPlayer");
	}

    /// <summary>
    /// If the player enters the objects collider and the player has no choice in scene change load the next scene
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject != player)
        {
            return;
        }

        if(!playerChoice)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    /// <summary>
    /// only happens if the player has a choice in scene loading
    /// if the player is in the collider and presses 'e' load the next scene
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject != player)
        {
            return;
        }

        if (playerChoice)
        {
            if (Input.GetKey(KeyCode.E))
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }
	

}
