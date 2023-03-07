using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsPlayerInRange : Node
{
    [SerializeField]private Transform origin;
    [SerializeField]private Transform target;
    [SerializeField] private float maxThreshold;

    public IsPlayerInRange(Transform origin, Transform target, float maxThreshold)
    {
        this.origin = origin;
        this.target = target;
        this.maxThreshold = maxThreshold;
    }

    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        return Vector3.Distance(origin.position, target.position) <= maxThreshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
