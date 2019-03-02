using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeDetection : MonoBehaviour {

    private GameObject player;
    private Transform pivotPoint;
    public bool playerDetected;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("tempPlayer");
        pivotPoint = transform.parent;

	}
	
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.DrawLine(pivotPoint.position, (player.transform.position - pivotPoint.position) * 10, Color.red);

        if(collider.gameObject != player)
        {
            return;
        }


        int playerLayer = player.gameObject.layer;

        if(Physics.Raycast(pivotPoint.position, (player.transform.position - pivotPoint.position)))
        {
            Debug.Log("made it past");

            playerDetected = true;

        }
        else
        {
            playerDetected = false;
        }


    }
}
