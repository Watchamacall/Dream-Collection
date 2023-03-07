using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IsPlayerClose : Node
{
    /*
     * Node in the Nightmare's BT
     * Returns SUCCESS if target is within maxThreshold of origin, FAILURE if not
     */
    protected float maxThreshold;

    /// <summary>
    /// Constructor for IsPlayerClose
    /// </summary>
    /// <param name="maxThreshold">The max distance the AI will look at</param>
    public IsPlayerClose(float maxThreshold)
    {
        this.maxThreshold = maxThreshold;
    }

    /// <summary>
    /// Evaluation of this Node
    /// </summary>
    /// <param name="blackboard">The BT_Blackboard the parent Node uses</param>
    /// <returns>SUCCESS if one or more player's are in radius, FAILURE if not</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        RaycastHit[] hits = Physics.SphereCastAll(blackboard.Origin.position, maxThreshold, Vector3.one);

        if (hits.Length > 0)
        {
            //Getting each RaycastHit that has the playerTag on it
            List<RaycastHit> playersHits = hits.Where(hit => hit.collider.CompareTag(blackboard.PlayerTag)).ToList();
            if (playersHits.Count > 0)
            {
                blackboard.RaycastHits = playersHits.ToArray();
                return NodeState.SUCCESS;       
            }
        }
        return NodeState.FAILURE;
    }
}
