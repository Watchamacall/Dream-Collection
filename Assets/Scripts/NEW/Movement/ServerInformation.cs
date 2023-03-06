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
        //TODO: Destory any objects that aren't needed for other Client's, set player number, name and colour
        if (!networkObject.IsOwner)
        {
            for (int i = 0; i < destroyElements.Length; i++)
            {
                Destroy(destroyElements[i]);
            }
        }
        networkObject.SendRpc(RPC_SEND_PLAYER_INFORMATION, Receivers.AllBuffered, new object[] { "New Name", new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255)) });
    }

    /// <summary>
    /// Leaves the game and set's scene to connection screen for client
    /// </summary>
    public void LeaveGame()
    {
        NetworkManager.Instance.Disconnect();
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private void Start()
    {
        GetComponentInChildren<Renderer>().material.color = playerColour;
    }

    public void LateUpdate()
    {
        if (networkObject != null)
        {
            if (networkObject.IsOwner)
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

    public override void SendPlayerInformation(RpcArgs args)
    {
        playerName = args.GetNext<string>();
        playerColour = args.GetNext<Color>();
    }
}
