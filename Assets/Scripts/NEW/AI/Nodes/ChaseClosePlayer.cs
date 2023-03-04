using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseClosePlayer : Node
{
    /*
     * Return RUNNING if it's possible to move towards target, FAILURE if not
     */
    protected Transform origin;
    protected Transform target;
    protected float moveSpeed;

    /// <summary>
    /// Returns running when moving towards <paramref name="target"/> from <paramref name="origin"/> based on <paramref name="moveSpeed"/>
    /// </summary>
    /// <param name="origin">The transform of the object you are moving from</param>
    /// <param name="target">The transform of the object you are moving to</param>
    /// <param name="moveSpeed">The speed <paramref name="origin"/> will move towards <paramref name="target"/></param>
    public ChaseClosePlayer(Transform origin, Transform target, float moveSpeed)
    {
        this.origin = origin;
        this.target = target;
        this.moveSpeed = moveSpeed;
    }

    public override NodeState Evaluate()
    {
        origin.position = Vector3.MoveTowards(origin.position, target.position, moveSpeed);
        return NodeState.RUNNING;
    }
}
