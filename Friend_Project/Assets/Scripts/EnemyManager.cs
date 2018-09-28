using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public List<GameObject> enemyList;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Death();
	}

    void Death()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            EnemyData temp = enemyList[i].GetComponent<EnemyData>();
            if ( temp.health <= 0)
            {
                Object.Destroy(enemyList[i]);
                enemyList.RemoveAt(i);
                i--;
              
            }

        }
    }

}
