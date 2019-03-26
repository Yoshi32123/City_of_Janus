using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour{

    public void Start()
    {
        
    }

    private SkillNode root;

    public void LearnSkill(SkillNode currentNode, int key)
    {
        //in case the node is not in the tree
        if(currentNode.Data.Key == 0)
        {
            return;
        }

        //base case
        if (currentNode.Data.Key == key)
        {
            currentNode.Data.Learned = true;
            return;
        }
        //recursive case
        if(currentNode.Data.Key > key)
        {
            LearnSkill(currentNode.Data.leftChild, key);
        }
        else
        {
            LearnSkill(currentNode.Data.rightChild, key);
        }

    }

    public void CreateSkill(string name, Skill skill, int key)
    {
        SkillNode newNode = new SkillNode();
        newNode.Create(name, skill, key);


        AddSkill(root, newNode);

    }

    private void AddSkill(SkillNode root, SkillNode addition)
    {
        //base case
        if (root.Data.Skill == null)
        {
            root = addition;
            return;
        }

        //rescursive case
        if(root.Data.Key > addition.Data.Key)
        {
            AddSkill(root.Data.leftChild, addition);
        }
        else
        {
            AddSkill(root.Data.rightChild, addition);
        }
        
    }

}
