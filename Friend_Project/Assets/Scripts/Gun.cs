using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject gun;
    public float angle;
    public int increment; 

	// Use this for initialization
	void Start ()
    {
        gun = Instantiate(gun, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        angle = -90;

        //for (float i = Mathf.PI / 4f; i <= 2f * Mathf.PI; i += (Mathf.Deg2Rad * 90))
        //{
        //    Debug.DrawRay(transform.position, new Vector3(Mathf.Cos(i), Mathf.Sin(i), transform.position.z).normalized);
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
        findGunPosition();
	}

    public void findGunPosition()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        if (angle == 360 | angle == -360)
        {
            angle = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= increment; 
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle += increment;
        }

        gun.transform.rotation = rotation;
    }
}
