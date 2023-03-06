using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Blackboard
{
    protected Transform origin;
    protected Transform target;
    protected RaycastHit[] castHits;
    protected string playerTag;

    public Transform Origin { get { return origin; } }
    public Transform Target { get { return target; } set { target = value; } }
    public RaycastHit[] RaycastHits { get { return castHits; } set { castHits= value; } }
    public string PlayerTag { get { return playerTag; } }
    
    public BT_Blackboard(Transform origin, string playerTag)
    {
        this.origin = origin;
        this.playerTag = playerTag;
    }
}
