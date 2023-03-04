using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerAssigned : Node
{
    /*
     * Return Failure if player is not assigned, SUCCESS if assigned
     */
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        return blackboard.Target == null ? NodeState.FAILURE : NodeState.SUCCESS;
    }
}
