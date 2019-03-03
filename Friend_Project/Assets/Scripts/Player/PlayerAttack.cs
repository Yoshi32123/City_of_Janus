using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages all of the player's attack functionality
/// Includes basic, sneak, and gun attacks
/// 
/// Authors: Freddy Stock, Trenton Plager
/// </summary>
public class PlayerAttack : MonoBehaviour {

    [SerializeField]
    private GameObject sceneController;
    private List<GameObject> enemies;
    [SerializeField]
    private int basicDamage;
    [SerializeField]
    private int sneakDamage;
    private GameObject enemyToAttack;
    [SerializeField]
    private float attackRadius;
    [SerializeField]
    private float sneakAttackRadius; 

	// Use this for initialization
	void Start () {
        enemies = sceneController.GetComponent<SceneController>().Enemies;
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if ((transform.position - enemies[i].transform.position).sqrMagnitude < Mathf.Pow(attackRadius, 2))
            {
                enemyToAttack = enemies[i];
                if (Input.GetKeyUp("E"))
                {
                    BasicAttack(enemyToAttack);
                }
                else if (Input.GetKeyUp("Q"))
                {
                    SneakAttack(enemyToAttack);
                }
                else
                {
                    GunAttack(enemyToAttack);
                }
            }
        }

    }

    /// <summary>
    /// Makes the player perform a basic attack
    /// And subtracts the value of basic damage from the target's health
    /// </summary>
    /// <param name="target">The target to perform an attack on</param>
    public void BasicAttack(GameObject target)
    {
        target.GetComponent<Data>().Health -= basicDamage;
    }

    /// <summary>
    /// Makse the player perform a sneak attack
    /// </summary>
    /// <param name="target">The target to perform an attack on</param>
    public void SneakAttack(GameObject target)
    {
        Vector3 playerPosEnemySpace = transform.position - target.transform.position; 
        
        //Logic to determine if player is close enough to the enemy
        //and if the player is behind the enemy
        if (playerPosEnemySpace.y < 0 && playerPosEnemySpace.sqrMagnitude <= Mathf.Pow(sneakAttackRadius, 2))
        {
            if (target.GetComponent<Data>() is EnemyData)
            {
                target.GetComponent<EnemyData>().Health -= sneakDamage;
            }
            //if the object is not an enemy subtract basic damage instead
            else if (target.GetComponent<Data>() is Data)
            {
                target.GetComponent<Data>().Health -= basicDamage;
            }
        }
    }

    /// <summary>
    /// Call gun's fire method
    /// </summary>
    /// <param name="target">The target to be attacked</param>
    public void GunAttack(GameObject target)
    {
        gameObject.GetComponent<Gun>().FireGun();
    }
}
