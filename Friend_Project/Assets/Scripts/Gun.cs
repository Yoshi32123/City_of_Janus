using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public GameObject gun;
    public GameObject bulletPrefab;
    public int numberOfBullets;
    public float angle;
    public List<GameObject> bullets; 

	// Use this for initialization
	void Start ()
    {
        gun = Instantiate(gun,
            new Vector3(transform.position.x, transform.position.y, transform.position.z), 
            findGunPosition());
    }
	
	// Update is called once per frame
	void Update ()
    {
        gun.transform.position = transform.position;
        gun.transform.rotation = findGunPosition();
        FireGun();
	}

    public Quaternion findGunPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouseWorldPos);

        Vector3 mousePosRelPlayer = new Vector3(transform.position.x - mouseWorldPos.x, transform.position.y - mouseWorldPos.y, 0);
        Debug.Log(mousePosRelPlayer);

        angle = Mathf.Atan2(mousePosRelPlayer.y, mousePosRelPlayer.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, (angle - 90f) + 180f);

        return rotation;
    }

    public void FireGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(numberOfBullets != 0)
            {
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                newBullet.GetComponent<BulletMovement>().direction = gameObject.GetComponent<PlayerMove>().Direction;
                numberOfBullets--;
            }
        }
    }
}
