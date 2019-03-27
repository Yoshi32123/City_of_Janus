using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillNode {

    public Node Data;
    public SkillUI UIbutton;

    public SkillNode()
    {
        Data = new Node();
    }
   

    public void Create(string name, Skill skill, int key, Button skillButton)
    {
        Data.SkillName = name;
        Data.Skill = skill;
        Data.Key = key;

        UIbutton = skillButton.GetComponent<SkillUI>();
        UIbutton.skillButton.onClick.AddListener(Learn);

        Data.Unlocked = false;
        Data.Learned = false;
    }

    public void Learn()
    {
        if (Data.Unlocked)
        {
            Debug.Log("<color=green>Skill Learned</color>");
            Data.Learned = true;
        }
        else
        {
            Debug.Log("<color=red>Cant Learn</color>");
        }
    }

    public struct Node
    {
        public int Key;

        public bool Unlocked;
        public bool Learned;

        public string SkillName;
        public Skill Skill;

        public SkillNode leftChild;
        public SkillNode rightChild;

    }


}
