using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    ///////////////////// Authors ///////////////////
    //Freddy Stock

    private float cameraWidth;
    private float cameraHeight;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    public float mass;
    public Vector3 direction = new Vector3(1, 0, 0);        // Right, 0 degrees
    public Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 acceleration = new Vector3(0, 0, 0);

    private Animation playerAnimation; 


    // Use this for initialization
    void Start () {
        playerAnimation = gameObject.GetComponent<Animation>(); 
	}
	
	// Update is called once per frame
	void Update () {
        ApplyMovementForces();
        Move();
	}

    /// <summary>
    /// applies a force in the direction that the player indicates with WASD
    /// /// </summary>
    void ApplyMovementForces()
    {
        direction = new Vector3(0, 0);
        playerAnimation.prevDirection = playerAnimation.Direction;
        if (Input.GetKey(KeyCode.W))
        {
            playerAnimation.Direction = DirectionFacing.Back;
            ApplyForce(new Vector3(0, speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerAnimation.Direction = DirectionFacing.Front;
            ApplyForce(new Vector3(0, -speed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerAnimation.Direction = DirectionFacing.Right;
            ApplyForce(new Vector3(speed, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerAnimation.Direction = DirectionFacing.Left;
            ApplyForce(new Vector3(-speed, 0));
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)) //if no keys out of WASD is pressed the plkayer should stop
        {
            velocity = Vector3.zero;
        }

    }

    /// <summary>
    /// applies a force to an object based on its mass
    /// </summary>
    /// <param name="force">force to apply</param>
    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
        playerAnimation.IsMoving = true;
    }

    /// <summary>
    /// move object based on forces
    /// </summary>
    private void Move()
    {
        velocity += acceleration;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.deltaTime;

        direction = velocity.normalized;
        acceleration = Vector3.zero;
    }
}
