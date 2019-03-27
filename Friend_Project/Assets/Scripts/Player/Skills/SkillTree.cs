using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree{

    private SkillNode root;

    public SkillTree()
    {
    }

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

    public void CreateSkill(string name, Skill skill, int key, Button skillButton)
    {
        SkillNode newNode = new SkillNode();
        newNode.Create(name, skill, key, skillButton);


        AddSkill(root, newNode);

    }

    private void AddSkill(SkillNode root, SkillNode addition)
    {
        //base case
        if (root == null)
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
