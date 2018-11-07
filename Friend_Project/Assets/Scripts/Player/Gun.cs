using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the functionality of the gun 
/// i.e. finds gun position and updates this position
/// Also fires the gun
/// 
/// Author: Trenton Plager
/// </summary>
public class Gun : MonoBehaviour {

    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private GameObject bulletPrefab;
    private int numberOfBullets;
    private float angle;
    private List<GameObject> bullets;
    [SerializeField]
    private int damage;

    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }

	// Use this for initialization
	void Start ()
    {
        gun = Instantiate(gun,
            new Vector3(transform.position.x, transform.position.y, transform.position.z), 
            FindGunPosition());
    }
	
	// Update is called once per frame
	void Update ()
    {
        gun.transform.position = transform.position;
        gun.transform.rotation = FindGunPosition();
	}

    /// <summary>
    /// Finds the gun's position using the camera and the mouse position
    /// </summary>
    /// <returns>A rotation Quaternion to apply to the gun</returns>
    public Quaternion FindGunPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mousePosRelPlayer = new Vector3(transform.position.x - mouseWorldPos.x, transform.position.y - mouseWorldPos.y, 0);

        angle = Mathf.Atan2(mousePosRelPlayer.y, mousePosRelPlayer.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, (angle - 90f) + 180f);

        return rotation;
    }

    public void FireGun(GameObject target)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(numberOfBullets != 0)
            {
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                newBullet.GetComponent<BulletMovement>().Direction = gameObject.GetComponent<PlayerMove>().direction;
                numberOfBullets--;

                target.GetComponent<Data>().Health -= damage;
            }
        }
    }
}
