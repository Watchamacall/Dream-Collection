using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : Node
{
    [SerializeField] private Transform origin;
    [SerializeField] private Transform target;
    [SerializeField] private int damageDealt;
    [SerializeField] private float damageCooldown;
    [SerializeField]private bool canDamage = false;

    private float curCooldown = 1;
    public DamagePlayer(Transform origin, Transform target, int damageDealt, float damageCooldown)
    {
        this.origin = origin;
        this.target = target;
        this.damageDealt = damageDealt;
        this.damageCooldown = damageCooldown;
    }

    public override NodeState Evaluate(BT_Blackboard blackboard)
    {
        
        if (canDamage)
        {
            target.gameObject.GetComponent<Move>().Health -= damageDealt;
            canDamage = false;
            return NodeState.SUCCESS;
        }

        if (curCooldown <= damageCooldown)
        {
            curCooldown += Time.deltaTime;
        }
        else
        {
            canDamage = true;
            curCooldown = 0;
        }
        
        return NodeState.FAILURE;
    }
}
