using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeDetection : MonoBehaviour {

    private GameObject player;
    private Transform pivotPoint;
    private float coneLen;
    public bool playerDetected;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("tempPlayer");
        pivotPoint = transform.parent;
        coneLen = 8;

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

        RaycastHit2D raycastInfo = Physics2D.Raycast(pivotPoint.position, (player.transform.position - pivotPoint.position), coneLen);
        Debug.Log(raycastInfo.collider.gameObject);
        if (raycastInfo.collider.gameObject == player)
        {

            playerDetected = true;
           
        }
        else //if it hit something there is something between the player and the goblin
        {
            playerDetected = false;
        }


    }
}
