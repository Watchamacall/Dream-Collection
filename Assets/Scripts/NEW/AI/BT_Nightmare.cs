using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Nightmare : MonoBehaviour
{
    /*
     * TODO: Setup a Blackboard and change Evaluate to require the Blackboard to run, use Blackboard for all information like origin, target. Use Ai itself for things like radius and that
     */

    private BT_Blackboard blackboard;
    [SerializeField, Tooltip("How close does this AI have to be to damage the target?")]
    protected float damageRange = 5.0f;
    [SerializeField, Tooltip("How close does this AI have to be to chase a target?")]
    protected float chaseRange = 5.0f;
    [SerializeField, Tooltip("The tag the player has")]
    protected string playerTag = "Player";
    [SerializeField, Tooltip("How much damage the AI does per hit")]
    protected float damageToDo = 5.0f;
    [SerializeField, Tooltip("How fast this AI will move")]
    protected float moveSpeed = 10.0f;

    private Node root;

    private void Start()
    {
        blackboard = new BT_Blackboard(transform, playerTag);

        #region Damage Player Sequence
        IsPlayerClose damageCloseCheck = new IsPlayerClose(damageRange);
        DamageClosestPlayer damageClosestPlayer = new DamageClosestPlayer(damageToDo);

        Sequence damagePlayerSequence = new Sequence(new List<Node> { damageCloseCheck, damageClosestPlayer });
        #endregion

        #region Chase Player Sequence
        IsPlayerClose chaseCloseCheck = new IsPlayerClose(chaseRange);
        #region Set Player Selector
        IsPlayerAssigned setPlayerAssigned = new IsPlayerAssigned();

        SetPlayer setPlayer = new SetPlayer();

        Selector setPlayerSelector = new Selector(new List<Node> { setPlayerAssigned, setPlayer });
        #endregion
        ChaseClosePlayer chaseClosePlayer = new ChaseClosePlayer(moveSpeed);

        Sequence chasePlayerSequence = new Sequence(new List<Node> { chaseCloseCheck, setPlayerSelector, chaseClosePlayer });
        #endregion

        #region Vibe Sequence
        #region Unset Player Selector
        #region Unset Player Assigned Inverter
        IsPlayerAssigned unsetPlayerAssigned = new IsPlayerAssigned();

        Inverter unsetPlayerAssignedInverter = new Inverter(unsetPlayerAssigned);
        #endregion
        SetPlayer unsetPlayer = new SetPlayer(false);

        Selector unsetPlayerSelector = new Selector(new List<Node> { unsetPlayerAssignedInverter, unsetPlayer });
        #endregion
        Sequence vibeSequence = new Sequence(new List<Node> { unsetPlayerSelector });
        #endregion
        #region Root Selector
        root = new Selector(new List<Node> { damagePlayerSequence, chasePlayerSequence, vibeSequence });
        #endregion
    }

    private void Update()
    {
        root.Evaluate(blackboard);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, chaseRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, damageRange);
    }
}
