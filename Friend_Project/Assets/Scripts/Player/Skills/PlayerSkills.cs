using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour {

    SkillTree playerTree;

	// Use this for initialization
	void Start () {

        playerTree = new SkillTree();
        playerTree.CreateSkill("test", new Skill(), 50);

        playerTree.CreateSkill("left", new Skill(), 25);
        playerTree.CreateSkill("Right", new Skill(), 75);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
