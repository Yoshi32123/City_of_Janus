using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour {

    private int health;
    private EnemyType type;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public EnemyType Type
    {
        get { return type; }
        set { type = value; }
    }
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
