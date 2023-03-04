using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BT_Blackboard : MonoBehaviour
{
    protected Transform origin;
    protected Transform target;
    protected RaycastHit[] castHits;

    public Transform Origin { get { return origin; } set { origin = value; } }
    public Transform Target { get { return target; } set { target = value; } }
    public RaycastHit[] RaycastHits { get { return castHits; } set { castHits= value; } }
    
    public BT_Blackboard(Transform origin)
    {
        this.origin = origin;
    }
}
