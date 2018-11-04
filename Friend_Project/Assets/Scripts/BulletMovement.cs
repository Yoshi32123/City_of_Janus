using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves the bullets after they are fired
/// 
/// Author: Trenton Plager
/// </summary>
public class BulletMovement : MonoBehaviour {

    private Vector3 direction;
    [SerializeField]
    private float speed;
    private Vector3 velocity;

    public Vector3 Direction
    {
        set { direction = value; }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
	}

    /// <summary>
    /// Moves the bullet in the direction it was given with a constant speed
    /// </summary>
    void Move()
    {
        transform.position += direction * speed;
    }
}
