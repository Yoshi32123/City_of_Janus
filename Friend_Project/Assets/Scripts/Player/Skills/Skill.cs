using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {

    public int cost;

    public Skill()
    {
        cost = -1;
    }

    public Skill(int cost)
    {
        this.cost = cost; 
    }

    public virtual void Effect() { }


}
