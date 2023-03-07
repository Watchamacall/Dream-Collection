using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageClosestPlayer : Node
{
    /*
     * One of the nodes in the Nightmare's BT
     * Returns SUCCESS when damaging the Blackboard's Target
     */
    float damageToDo;

    /// <summary>
    /// Constructor for DamageClosestPlayer
    /// </summary>
    /// <param name="damageToDo">The damage the AI will do</param>
    public DamageClosestPlayer(float damageToDo)
    {
        this.damageToDo = damageToDo;
    }

    /// <summary>
    /// Evaluation of this Node
    /// </summary>
    /// <param name="blackboard">The BT_Blackboard the parent Node uses</param>
    /// <returns>SUCCESS when damaging Target Var</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        blackboard.Target.GetComponent<Health>().SetHealth(damageToDo * Time.deltaTime);
        return NodeState.SUCCESS;
    }
}
