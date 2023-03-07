using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : NightmareObjectBehavior
{
    /*
     * Follow the player and send object's position and rotation
     */

    /// <summary>
    /// Destroy BT if not Server
    /// </summary>
    protected override void NetworkStart()
    {
        if (!networkObject.IsServer)
        {
            Destroy(GetComponent<BT_Nightmare>());
        }
    }

    /// <summary>
    /// Send or Recieve position/rotation based on whether Server or Client
    /// </summary>
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
