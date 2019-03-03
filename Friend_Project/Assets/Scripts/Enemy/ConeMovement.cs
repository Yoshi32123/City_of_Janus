using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeMovement : MonoBehaviour {

    public GameObject gob;

    Vector3 looking;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        looking = gob.GetComponent<EnemyMovement>().direction;
        RotateCone();
	}

    /// <summary>
    /// rotates cone to direction the parent looking
    /// </summary>
    private void RotateCone()
    {


        //Find rotation from x axis

        float rotation = Mathf.Atan2(looking.y, looking.x);
        rotation = rotation * Mathf.Rad2Deg;


        //set cone rotation to that
        Quaternion temp = Quaternion.Euler(0, 0, rotation);

        transform.rotation = temp;
        //Debug.Log(transform.rotation.z);

    }
}
