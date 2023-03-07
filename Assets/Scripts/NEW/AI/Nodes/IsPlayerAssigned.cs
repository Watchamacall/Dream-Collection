using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerAssigned : Node
{
    /*
     * Return Failure if player is not assigned, SUCCESS if assigned
     */

    /// <summary>
    /// Evaluation of this Node
    /// </summary>
    /// <param name="blackboard">The BT_Blackboard the parent Node uses</param>
    /// <returns>FAILURE if Target is not assigned, SUCCESS if Target is</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        return blackboard.Target == null ? NodeState.FAILURE : NodeState.SUCCESS;
    }
}
