using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {

    SkillTree playerTree;

	// Use this for initialization
	void Start () {

        playerTree.CreateSkill("test", new Skill(), 1);


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
