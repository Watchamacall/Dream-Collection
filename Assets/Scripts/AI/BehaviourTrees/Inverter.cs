using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{

    protected Node node; //The node we will be inverting

    public Inverter(Node node)
    {
        this.node = node; //Constructor
    }

    public override NodeState Evaluate()
    {
        switch (node.Evaluate())
        {
            case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                break;

            case NodeState.SUCCESS:
                _nodeState = NodeState.FAILURE;
                break;

            case NodeState.FAILURE:
                _nodeState = NodeState.SUCCESS;
                return _nodeState;

            default:
                break;
        }
        return _nodeState;
    }
}
