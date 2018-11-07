using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    /////////////////// Authors //////////////////////
    // Freddy Stock

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    public float mass;
    public Vector3 direction = new Vector3(1, 0, 0);        // Right, 0 degrees
    public Vector3 velocity = new Vector3(0, 0, 0);
    public Vector3 acceleration = new Vector3(0, 0, 0);

    public Transform[] patrolPath;
    private int currentPatrolNode;

    //fields related to detection chance
    private float distToPlayer;
    public float detectionChance;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float detectionSpeed;

    //booleans representing the diffrent states an ai can be in
    public bool normal;
    public bool alerted;
    public bool detected;

    // Use this for initialization
    void Start()
    {
        normal = true;
        alerted = false;
        detected = false;

        currentPatrolNode = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Patrol();
        Move();

        distToPlayer = (Mathf.Pow((player.transform.position.x - transform.position.x), 2) + Mathf.Pow((player.transform.position.y - transform.position.y), 2));
        //detected = PlayerInSight();

        PlayerDetected();


    }

    /// <summary>
    /// Helper method to player Detected will instantly detect player if in line of sight
    /// CURRENT NOT FINISHED TEMP SOLUTION IMPLEMENTED
    /// </summary>
    /// <returns></returns>
    private void PlayerInSight()
    {


        if (distToPlayer <= 4)
        {
            detectionChance = 1;
        }
    }

    /// <summary>
    /// currently distance increases chance of being detected and once that passes a certain amount the player is detected
    /// this is just for testing eventually more factors will determine detection chance and way that the player is detected maybe changed
    /// </summary>
    /// <returns></returns>
    private void PlayerDetected()
    {
        PlayerInSight();

        if (detectionChance > 1)//limit detection chance to 100%
        {
            detectionChance = 1;
        }
        if (detectionChance < 0)//stop detection chance from dropping below 0%
        {
            detectionChance = 0;
        }

        if (distToPlayer <= Mathf.Pow(4f, 2f)) //greater than 4^2 cause distance to player is never square rooted
        {
            detectionChance += detectionSpeed * Time.deltaTime;
        }
        else
        {
            detectionChance -= (detectionSpeed / 2) * Time.deltaTime;
        }

        if (detectionChance >= .75f)
        {

            normal = false;
            alerted = false;
            detected = true;
        }
        else
        {
            normal = true;
            alerted = false;
            detected = false;
        }
    }

    /// <summary>
    /// follows a set patrol path
    /// moves towards next location and when it gets close to it moves the the next location
    /// </summary>
    private void Patrol()
    {
        if(Vector3.Distance(transform.position, patrolPath[currentPatrolNode].position) > .5f) //range because otherwise the character may over shoot
        {
            ApplyForce(patrolPath[currentPatrolNode].position - transform.position);
        }
        else
        {
            
            if (currentPatrolNode == patrolPath.Length - 1)
            {
                currentPatrolNode = 0;
            }
            else
            {
                currentPatrolNode++;
            }
        }
    }

    /// <summary>
    /// applies a force to an object based on its mass
    /// </summary>
    /// <param name="force">force to apply</param>
    private void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
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
