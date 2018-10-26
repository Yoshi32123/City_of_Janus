using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 direction;
    private Vector3 velocity;
    [SerializeField]
    private float speed; //default is 5

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
            direction.y = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction.x = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -speed;
        }
        velocity = direction.normalized * speed;

        transform.position += velocity * Time.deltaTime;
    }
}
