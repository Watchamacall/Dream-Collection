using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NightmareObject : MonoBehaviour
{
    //TODO: Need to check if the player has collected this enemy and get them to start chasing the player that clicked on them. If the player is far enough away the enemy then disappears, or if the player does xyz to the enemy to them injure them (Could use a dream to stop them (Cancel them out))

    //TODO: Setup the BehaviourMaster to get the Behaviour Tree setup

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODO: Setup the AI to start chasing
        }
    }
}
