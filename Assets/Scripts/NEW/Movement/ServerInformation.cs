using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Random = UnityEngine.Random;
public class ServerInformation : PlayerBehavior
{
    /*
     * Sends and recieves information about the GameObject it is attached to.
     * Sends any relevant information to the other clients as well has holding all relevent information about this client in particular
     */
    [SerializeField, Tooltip("The name of the player")]
    public string playerName;
    [SerializeField, Tooltip("The base colour of the player")]
    public Color playerColour;

    [SerializeField, Tooltip("All elements you want to remove from these elements if not the owner")]
    protected UnityEngine.Object[] destroyElements;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsOwner) //Destroying all elements if not owner, saves resources
        {
            for (int i = 0; i < destroyElements.Length; i++)
            {
                Destroy(destroyElements[i]);
            }
        }
        networkObject.SendRpc(RPC_SEND_PLAYER_INFORMATION, Receivers.AllBuffered, new object[] { "New Name", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)) }); //Sending RPC to other users about their name and colour (New Name is generic for now)
    }

    private void OnDisable()
    {
        networkObject.SendRpc(RPC_DESTROY_PLAYER, Receivers.AllBuffered);
    }

    /// <summary>
    /// Leaves the game and set's scene to connection screen for client
    /// </summary>
    public void LeaveGame()
    {
        NetworkManager.Instance.Disconnect();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LateUpdate()
    {
        if (networkObject != null)
        {
            if (networkObject.IsOwner) //Sending information about Owner to other Client's
            {
                networkObject.position = transform.position;
                networkObject.rotation = transform.rotation;
            }
            else //Recieving data from Owner about this Client
            {
                transform.position = networkObject.position;
                transform.rotation = networkObject.rotation;
            }
        }
    }

    /// <summary>
    /// Sending/Recieving infomation about this Client
    /// </summary>
    /// <param name="args">0 is string for name, 1 is Color for playerColor</param>
    public override void SendPlayerInformation(RpcArgs args)
    {
        playerName = args.GetNext<string>();
        playerColour = args.GetNext<Color>();

        GetComponentInChildren<Renderer>().material.color = playerColour; //Get Child Component since the object this script is attached to doesn't have a Renderer
    }

    /// <summary>
    /// Sends instructions to Client's to destroy this GameObject
    /// </summary>
    /// <param name="args">N/A</param>
    public override void DestroyPlayer(RpcArgs args)
    {
        Destroy(this.gameObject);
    }
}
