using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private GameObject manager;
    private List<GameObject> enemyList;
    [SerializeField]
    private int damage;

	// Use this for initialization
	void Start () {
        enemyList = manager.GetComponent<EnemyManager>().enemyList;
	}
	
	// Update is called once per frame
	void Update () {
        attack();
	}

    /// <summary>
    /// 
    /// </summary>
    public void attack()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i].GetComponent<Collider2D>().OverlapPoint(transform.position))
            {
                enemyList[i].GetComponent<EnemyData>().health -= damage;

            }
            
            //if(CollisionDetection(new Rect(enemyList[i].transform.position, enemyList[i].GetComponent<Collider2D>().bounds.size)))
            //{
            //}
           
        }
    }

    bool CollisionDetection(Rect enemyRect)
    {
        
        return (enemyRect.Contains(transform.position));

    }
}
