using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Blackboard
{
    /*
     * Generic class for holding all variables to be get or set
     */
    [Tooltip("The Transform this script is attached to")]
    protected Transform origin;
    [Tooltip("The Transform of the Target you wish to move towards")]
    protected Transform target;
    [Tooltip("The Array of Hits that is compiled when checking \"IsPlayerClose\"")]
    protected RaycastHit[] castHits;
    [Tooltip("The tag the Player is attached to")]
    protected string playerTag;

    #region Get/Set functions
    public Transform Origin { get { return origin; } }
    public Transform Target { get { return target; } set { target = value; } }
    public RaycastHit[] RaycastHits { get { return castHits; } set { castHits= value; } }
    public string PlayerTag { get { return playerTag; } }
    #endregion
    /// <summary>
    /// Constructor for BT_Blackboard
    /// </summary>
    /// <param name="origin">The Transform this script is attached to</param>
    /// <param name="playerTag">The tag the Player has attached to it</param>
    public BT_Blackboard(Transform origin, string playerTag)
    {
        this.origin = origin;
        this.playerTag = playerTag;
    }
}
