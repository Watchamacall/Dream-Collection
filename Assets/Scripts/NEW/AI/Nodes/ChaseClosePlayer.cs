using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseClosePlayer : Node
{
    /*
     * Return RUNNING if it's possible to move towards target, FAILURE if not
     */
    protected float moveSpeed;
    /// <summary>
    /// Returns running when moving towards <paramref name="target"/> from <paramref name="origin"/> based on <paramref name="moveSpeed"/>
    /// </summary>
    /// <param name="origin">The transform of the object you are moving from</param>
    /// <param name="target">The transform of the object you are moving to</param>
    /// <param name="moveSpeed">The speed <paramref name="origin"/> will move towards <paramref name="target"/></param>
    public ChaseClosePlayer(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        blackboard.Origin.position = Vector3.MoveTowards(blackboard.Origin.position, blackboard.Target.position, moveSpeed);
        return NodeState.RUNNING;
    }
}
