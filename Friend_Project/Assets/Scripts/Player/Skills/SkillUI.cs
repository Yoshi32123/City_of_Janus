using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public Button skillButton;
    public GameObject player;
    private PlayerSkills playerTree;

	// Use this for initialization
	void Start () {
        playerTree = player.GetComponent<PlayerSkills>();
        playerTree.GenerateTree();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
