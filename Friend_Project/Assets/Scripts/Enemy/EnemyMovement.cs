using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    /////////////////// Authors //////////////////////
    // Freddy Stock
    // https://www.youtube.com/watch?v=fKWTpi70a_E was used as a refrence for the Patrol() method

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;

    public Vector3 targetPosition;
    protected Vector3 desiredVelocity;
    protected Vector3 seekingForce;

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
    private float detectionRadius;


    protected GameObject player;
    [SerializeField]
    private float detectionSpeed;

    //booleans representing the diffrent states an ai can be in
    public bool normal;
    public bool alerted;
    public bool detected;

    //matrix used for vetor rotations
    private float[,] rotationMatrix;

    private Vector3 detectVectorLeft;
    private Vector3 detectVectorRight;
    private Vector3 centerDetectionCone;


    private ConeDetection DetectionCone;


    // Use this for initialization
    void Start()
    {

        DetectionCone = GetComponentInChildren<ConeDetection>();


        player = GameObject.Find("tempPlayer");
        normal = true;
        alerted = false;
        detected = false;

        detectVectorLeft = new Vector3(transform.position.x + Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);
        detectVectorRight = new Vector3(transform.position.x - Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);
        centerDetectionCone = transform.position + transform.forward;


        currentPatrolNode = 0;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (!detected)
        {
            Patrol();
        }
        else
        {
            ApplyForce(Seek(player.transform.position));
            //Debug.Log(player.transform.position);
        }
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
    private bool PlayerInSight()
    {

        return DetectionCone.playerDetected;
        ////debug lines of the detection cone
        ////Debug.DrawLine(transform.position, new Vector3(transform.position.x + Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius)); 
        ////Debug.DrawLine(transform.position, new Vector3(transform.position.x - Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius));


        //Vector3 playerEnSpace = player.transform.position - transform.position;//convert the player's coordinates to this objects coordinates

        ////detection vectors left and right are based on when the y value of both vectors is positive
        ////Vector3 detectVectorLeft = new Vector3(transform.position.x - Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);
        ////Vector3 detectVectorRight = new Vector3(transform.position.x + Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);



        ////rotate the detection vectors based on the direction of movement


        ////centerDetectionCone = direction;
        ////Vector3 detectVectorLeft = new Vector3(transform.position.x - Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);
        ////
        ////else
        ////{
        ////    Debug.Log("here");
        ////}

        //detectVectorLeft = new Vector3(transform.position.x + Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);
        //detectVectorRight = new Vector3(transform.position.x - Mathf.Cos(Mathf.PI / 3) * detectionRadius, transform.position.y + Mathf.Sin(Mathf.PI / 3) * detectionRadius);
        ////centerDetectionCone = transform.position + tran;



        //Debug.DrawLine(transform.position,  detectVectorLeft);
        //Debug.DrawLine(transform.position,  detectVectorRight);
        //Debug.DrawLine(transform.position,  centerDetectionCone);



        //if (playerEnSpace.y > 0 && // if the player is withing a 60 degree cone infront of the enemy they are detected
        //    Mathf.Atan2(playerEnSpace.y, playerEnSpace.x) * Mathf.Rad2Deg > 60 &&
        //    Mathf.Atan2(playerEnSpace.y, playerEnSpace.x) * Mathf.Rad2Deg < 120 &&
        //    playerEnSpace.sqrMagnitude < Mathf.Pow(detectionRadius, 2))
        //{
        //    detectionChance = 1;
        //}

    }

    /// <summary>
    /// currently distance increases chance of being detected and once that passes a certain amount the player is detected
    /// this is just for testing eventually more factors will determine detection chance and way that the player is detected maybe changed
    /// </summary>
    /// <returns></returns>
    private void PlayerDetected()
    {
        if (PlayerInSight())
        {
            detectionChance = 1;
        }

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
            Vector3 directionToPoint = new Vector3(patrolPath[currentPatrolNode].position.x - transform.position.x, patrolPath[currentPatrolNode].position.y - transform.position.y, 0);

            ApplyForce(directionToPoint);

            float rotDegree = Mathf.Atan2(directionToPoint.y, directionToPoint.x);

            rotDegree = rotDegree / 100;

            centerDetectionCone = Rotate(rotDegree, centerDetectionCone);

            //Debug.Log(centerDetectionCone);
            
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <returns></returns>
    protected Vector3 Seek(Vector3 targetPosition)
    {
        desiredVelocity = new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, 0);

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        seekingForce = desiredVelocity - velocity;

        return seekingForce;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetPosition"></param>
    /// <returns></returns>
    protected Vector3 Flee(Vector3 targetPosition)
    {
        desiredVelocity = -new Vector3(targetPosition.x - transform.position.x, targetPosition.y - transform.position.y, 0);

        desiredVelocity = desiredVelocity.normalized * maxSpeed;

        seekingForce = desiredVelocity - velocity;

        return seekingForce;
    }


    /// <summary>
    /// rotates a given Vector
    /// </summary>
    /// <param name="radians">rotation in radians</param>
    /// <param name="vector">vector to be rotated</param>
    /// <returns>rotated vector</returns>
    private Vector3 Rotate(float radians, Vector3 vector)
    {

        Vector3 rotatedVector = new Vector3();

        rotationMatrix = new float[2, 2];
        rotationMatrix[0, 0] = Mathf.Cos(radians);
        rotationMatrix[0, 1] = -Mathf.Sin(radians);
        rotationMatrix[1, 0] = Mathf.Sin(radians);
        rotationMatrix[1, 1] = Mathf.Cos(radians);

        //matrix multiplication
        rotatedVector.x = (rotationMatrix[0, 0] * vector.x) +(rotationMatrix[0, 1] * vector.y) ;
        rotatedVector.y = (rotationMatrix[1, 0] * vector.x) + (rotationMatrix[1, 1] * vector.y);


        return rotatedVector;
    }
}
