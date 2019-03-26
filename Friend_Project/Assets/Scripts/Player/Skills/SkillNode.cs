using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillNode : MonoBehaviour {

    public Node Data;
    private void Start()
    {
        
    }

    public void Create(string name, Skill skill, int key)
    {
        Data.SkillName = name;
        Data.Skill = skill;
        Data.Key = key;
        Data.Unlocked = false;
        Data.Learned = false;
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
