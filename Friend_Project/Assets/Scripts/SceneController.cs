using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    private int enemyNumber;
    private List<Vector3> enemyPositions;
    private List<GameObject> enemies;
    [SerializeField]
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
        playerStartPos = new Vector3(-15.2f, -11.8f, 0);
        enemies = new List<GameObject>();
        player.transform.position = playerStartPos;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //CheckEnemyDeath();
	}

    public void RespawnPlayer()
    {
        player.transform.position = playerStartPos; 
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
