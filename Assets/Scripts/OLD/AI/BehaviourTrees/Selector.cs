using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>(); //The list of nodes in which we will be sequencing through

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes; //Constructor
    }

    /// <summary>
    /// Evaluate the nodes currently in "nodes". Will fail only if all nodes fail
    /// </summary>
    /// <returns>First node that is Running or Successful</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        foreach (Node node in nodes)
        {
            switch (node.Evaluate(blackboard))
            {
                case NodeState.RUNNING:
                    _nodeState = NodeState.RUNNING;
                    return _nodeState;

                case NodeState.SUCCESS:
                    _nodeState = NodeState.SUCCESS;
                    return _nodeState;

                case NodeState.FAILURE:
                    break;

                default:
                    break;
            }
        }
        _nodeState = NodeState.FAILURE;
        return _nodeState;
    }
}
