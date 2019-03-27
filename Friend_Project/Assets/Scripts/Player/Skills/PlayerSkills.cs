using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour {

    private SkillTree playerTree;
    public List<Button> skillButtons;

	// Use this for initialization
	void Start () {

    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateTree()
    {
        playerTree = new SkillTree();
        playerTree.CreateSkill("test", new Skill(), 50, skillButtons[0]);


        playerTree.CreateSkill("left", new Skill(), 25, skillButtons[1]);
        playerTree.CreateSkill("Right", new Skill(), 75, skillButtons[2]);
    }
}
