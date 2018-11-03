using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    private int enemyNumber;
    private List<Vector3> enemyPositions;
    private List<GameObject> enemies;
    private GameObject player;
    private Vector3 playerStartPos;

    public List<GameObject> Enemies
    {
        get { return enemies; }
    }

    public GameObject Player
    {
        get { return player; }
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckEnemyDeath();
	}

    public void RespawnPlayer()
    {

    }

    public void RestartLevel()
    {

    }

    public void CheckEnemyDeath()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<EnemyData>().Health <= 0)
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
                i--;
            }
        }
    }
}
