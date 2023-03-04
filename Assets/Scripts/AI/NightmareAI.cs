using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareAI : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float chaseRange;
    [SerializeField] private float damageRange;
    [SerializeField] private int damageDeal;
    [SerializeField] private float damageCooldown;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Color chaseGizmosColour = Color.red;
    [SerializeField] private Color damageGizmosColour = Color.blue;
    BT_Blackboard blackboard;

    private Node topNode;

    // Start is called before the first frame update
    void Start()
    {
        blackboard = new BT_Blackboard(this.transform);
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        ConstructBehaviourTree();   
    }


    void Update()
    {
        topNode.Evaluate(blackboard);
    }

    private void ConstructBehaviourTree()
    {
        IsPlayerInRange playerDamageRange = new IsPlayerInRange(this.transform, playerTransform, damageRange);
        DamagePlayer damagePlayer = new DamagePlayer(this.transform, playerTransform, damageDeal, damageCooldown);

        IsPlayerInRange playerChaseRange = new IsPlayerInRange(this.transform, playerTransform, chaseRange);
        ChasePlayer chasePlayer = new ChasePlayer(this.transform, playerTransform, moveSpeed * Time.deltaTime);

        DestroyMe destroyMe = new DestroyMe(this.transform);

        Sequence playerDamageSeq = new Sequence(new List<Node>() { playerDamageRange, damagePlayer });

        Sequence chasePlayerSeq = new Sequence(new List<Node>() { playerChaseRange, chasePlayer });


        topNode = new Selector(new List<Node>() { playerDamageSeq, chasePlayerSeq, destroyMe });
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = chaseGizmosColour;
        Gizmos.DrawWireSphere(this.transform.position, chaseRange);
        
        Gizmos.color = damageGizmosColour;
        Gizmos.DrawWireSphere(this.transform.position, damageRange);
    }
}
