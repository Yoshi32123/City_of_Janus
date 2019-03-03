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


    /// <summary>
    /// when a collider enters the detection cone this method occurs
    /// 1. checks that the collider that entered was the palyer
    /// 2. Raycasts to check that the player doesnt have a obstacle blocking the enemy's los
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.gameObject != player)
        {
            return;
        }
        //Debug.DrawLine(pivotPoint.position, (player.transform.position - pivotPoint.position) * 10, Color.red, .5f);

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
