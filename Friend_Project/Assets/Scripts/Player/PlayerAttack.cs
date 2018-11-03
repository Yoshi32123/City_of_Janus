using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private GameObject sceneController;
    private List<GameObject> enemies;
    [SerializeField]
    private int damage;

	// Use this for initialization
	void Start () {
        enemies = sceneController.GetComponent<SceneController>().Enemies;
	}
	
	// Update is called once per frame
	void Update () {
        GenericAttack();
	}

    public void GenericAttack()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<Collider2D>().OverlapPoint(transform.position))
            {
                enemies[i].GetComponent<EnemyData>().health -= damage;

            }
            
            //if(CollisionDetection(new Rect(enemyList[i].transform.position, enemyList[i].GetComponent<Collider2D>().bounds.size)))
            //{
            //}
           
        }
    }

    public void SneakAttack()
    {
        
    }

    public void GunAttack()
    {
        gameObject.GetComponent<Gun>().FireGun();
    }

    bool CollisionDetection(Rect enemyRect)
    {
        
        return (enemyRect.Contains(transform.position));

    }
}
