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
    public SetPlayer(bool setPlayer = true)
    {
        this.setPlayer = setPlayer;
    }

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
