using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : Node
{
    private Transform origin;

    public DestroyMe(Transform origin)
    {
        this.origin = origin;
    }

    public override NodeState Evaluate()
    {
        try
        {
            GameObject.Destroy(origin.gameObject);
            return NodeState.SUCCESS;
        }
        catch (System.Exception)
        {
            return NodeState.FAILURE;
        }
    }
}
