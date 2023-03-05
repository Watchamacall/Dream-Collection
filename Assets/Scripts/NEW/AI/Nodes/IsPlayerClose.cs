using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IsPlayerClose : Node
{
    /*
     * Return SUCCESS if target is within maxThreshold of origin, FAILURE if not
     */
    protected float maxThreshold;

    /// <summary>
    /// Returns Success if there is a player within <paramref name="maxThreshold"/> and <paramref name="origin"/>
    /// </summary>
    /// <param name="player">The outputted player if in radius</param>
    /// <param name="origin">The origin transform</param>
    /// <param name="maxThreshold">How far out from <paramref name="origin"/> any <paramref name="player"/> can be</param>
    public IsPlayerClose(float maxThreshold)
    {
        this.maxThreshold = maxThreshold;
    }


    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        RaycastHit[] hits = Physics.SphereCastAll(blackboard.Origin.position, maxThreshold, Vector3.forward);

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
