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

    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false; //Check to see if any children are running

        foreach (Node node in nodes)
        {
            switch (node.Evaluate())
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
