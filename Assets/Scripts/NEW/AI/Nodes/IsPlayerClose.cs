using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IsPlayerClose : Node
{
    /*
     * Return SUCCESS if target is within maxThreshold of origin, FAILURE if not
     */
    protected Transform target;
    protected Transform origin;
    protected float maxThreshold;
    protected string playerTag;

    /// <summary>
    /// Returns Success if there is a player within <paramref name="maxThreshold"/> and <paramref name="origin"/>
    /// </summary>
    /// <param name="player">The outputted player if in radius</param>
    /// <param name="origin">The origin transform</param>
    /// <param name="maxThreshold">How far out from <paramref name="origin"/> any <paramref name="player"/> can be</param>
    public IsPlayerClose(Transform target, Transform origin, float maxThreshold, string playerTag)
    {
        this.target = target;
        this.origin = origin;
        this.maxThreshold = maxThreshold;
        this.playerTag = playerTag;
    }


    public override NodeState Evaluate()
    {
        RaycastHit[] hits = Physics.SphereCastAll(origin.position, maxThreshold, Vector3.forward);

        if (hits.Length > 0)
        {
            //Getting each RaycastHit that has the playerTag on it
            List<RaycastHit> playersHits = hits.Where(hit => hit.collider.CompareTag(playerTag)).ToList();
            if (playersHits.Count > 0)
            {
                //Casting these to Transform
                List<Transform> players = new List<Transform>();
                playersHits.ForEach(hit => players.Add(hit.collider.GetComponent<Transform>()));

                if (!target)
                {
                    Transform closestPlayer = players[0];
                    for (int i = 1; i < players.Count; i++)
                    {
                        //If new player is closer than closestPlayer
                        if (Vector3.Distance(origin.position, players[i].position) < Vector3.Distance(origin.position, closestPlayer.position))
                        {
                            closestPlayer = players[i];
                        }
                    }
                    target = closestPlayer;
                }
                return NodeState.SUCCESS;
            }
        }
        target = null;
        return NodeState.FAILURE;
    }
}
