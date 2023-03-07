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
    /// Constructor for ChaseClosePlayer
    /// </summary>
    /// <param name="moveSpeed">The speed the GameObject will move at</param>
    public ChaseClosePlayer(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    /// <summary>
    /// Evaluation for this Node
    /// </summary>
    /// <param name="blackboard">The BT_Blackboard the parent Node uses</param>
    /// <returns>RUNNING whilst moving towards the Target Var and looking at Target</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        blackboard.Origin.position = Vector3.MoveTowards(blackboard.Origin.position, blackboard.Target.position, moveSpeed * Time.deltaTime);
        blackboard.Origin.LookAt(blackboard.Target, Vector3.up);
        return NodeState.RUNNING;
    }
}
