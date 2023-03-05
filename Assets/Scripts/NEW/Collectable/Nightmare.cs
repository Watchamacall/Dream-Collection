using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : NightmareObjectBehavior
{
    /*
     * Follow the player and send object's position and rotation
     */


    // Update is called once per frame
    void LateUpdate()
    {
        //Only send updates if Server, otherwise will make AI freak out
        if (networkObject.IsServer)
        {
            networkObject.position = transform.position;
            networkObject.rotation = transform.rotation;
        }
        else
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
        }
    }
}
