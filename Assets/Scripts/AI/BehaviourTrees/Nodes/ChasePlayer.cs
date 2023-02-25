using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : Node
{
    private Transform origin;
    private Transform target;
    private float moveSpeed;
    public ChasePlayer(Transform origin, Transform target, float moveSpeed)
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
