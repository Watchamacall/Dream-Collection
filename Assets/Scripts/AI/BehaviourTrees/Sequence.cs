using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{

    protected List<Node> nodes = new List<Node>(); //The list of nodes in which we will be sequencing through

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes; //Constructor
    }

    /// <summary>
    /// Evaluate all nodes in "nodes". Fails if one fails or returns running if a node is running else success
    /// </summary>
    /// <returns>Fail if one node fails. Running if one or more is running. Success if none of the above are done</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        bool isAnyNodeRunning = false; //Check to see if any children are running

        foreach (Node node in nodes)
        {
            switch (node.Evaluate(blackboard))
            {
                case NodeState.RUNNING:
                    isAnyNodeRunning = true;
                    break;

                case NodeState.SUCCESS:
                    break;

                case NodeState.FAILURE: //If any node fails, break sequence and return
                    _nodeState = NodeState.FAILURE;
                    return _nodeState;

                default:
                    break;
            }
        }

        _nodeState = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS; //Lambda for if (isAnyNodeRunning) { _nodeState = NodeState.RUNNING; } else { _nodeState = NodeState.SUCCESS; }
        return _nodeState;
    }
}
