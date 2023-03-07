using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static UnityEngine.UI.Image;

public class SetPlayer : Node
{
    /*
     * Return SUCCESS if the player has been set, FAILURE otherwise. Implement bool for set or unset, saves using same thing but changing it a little (if (bool) {SetPlayer} else {UnsetPlayer})
     */

    protected bool setPlayer;
    /// <summary>
    /// Constructor for SetPlayer
    /// </summary>
    /// <param name="setPlayer">Whether to set or unset the Target BT_Blackboard variable</param>
    public SetPlayer(bool setPlayer = true)
    {
        this.setPlayer = setPlayer;
    }

    /// <summary>
    /// Evaluation of this node
    /// </summary>
    /// <param name="blackboard">The BT_Blackboard the parent Node uses</param>
    /// <returns>SUCCESS no matter if it Sets or UnSets the Target Var</returns>
    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        Transform closestPlayer = blackboard.RaycastHits[0].collider.GetComponent<Transform>();

        if (setPlayer)
        {
            //Casting these to Transform
            List<Transform> players = new List<Transform>();
            blackboard.RaycastHits.ToList().ForEach(hit => players.Add(hit.collider.GetComponent<Transform>()));

            for (int i = 1; i < players.Count; i++)
            {
                //If new player is closer than closestPlayer
                if (Vector3.Distance(blackboard.Origin.position, players[i].position) < Vector3.Distance(blackboard.Origin.position, closestPlayer.position))
                {
                    closestPlayer = players[i];
                }
            }
        }

        blackboard.Target = setPlayer ? closestPlayer : null;
        return NodeState.SUCCESS;
    }
}
