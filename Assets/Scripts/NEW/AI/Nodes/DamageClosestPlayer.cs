using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageClosestPlayer : Node
{
    float damageToDo;

    public DamageClosestPlayer(float damageToDo)
    {
        this.damageToDo = damageToDo;
    }
     /*
      * Return RUNNING if player damaged, failure if not
      */   
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        blackboard.Target.GetComponent<ClientController>().Health -= damageToDo;
        return NodeState.SUCCESS;
    }
}
