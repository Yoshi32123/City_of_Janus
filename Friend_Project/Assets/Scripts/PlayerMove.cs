using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 direction;
    private Vector3 velocity;
    [SerializeField]
    private float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    /// <summary>
    /// moves object based on keyboard inputs 
    /// </summary>
    void Move()
    {
        direction = new Vector3(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        velocity = direction.normalized * speed;

        transform.position += velocity;
    }
}
