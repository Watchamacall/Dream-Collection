using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;
using UnityEngine.InputSystem;

public class PlayerRoot : PlayerBehavior
{
    [Tooltip("The material in which the second player will look like")]
    public Material secondPlayerMat;
    [Tooltip("The name of the child of this object which holds the model")]
    public string modelName;

    [Tooltip("The child of this object which holds the model")]
    GameObject modelObj;

    public override void SendPlayerInformation(RpcArgs args)
    {
        throw new System.NotImplementedException();
    }

    protected override void NetworkStart()
    {
        base.NetworkStart();

        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in this.gameObject.transform) //Gets each child of this object and adds it to the list unless it matches the modelName
        {

            if (child.gameObject.name == modelName)
            {
                modelObj = child.gameObject;
            }
            else
            {
                children.Add(child.gameObject);
            }
        }


        if (!networkObject.IsOwner) //Not the owner of the Object
        {
            //Destroy children to stop main client moving other clients.
            //This is done to allow for other clients to be mapped to the local client
            foreach (GameObject child in children)
            {
                Destroy(child);
            }
            Destroy(GetComponent<Move>());
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<PlayerInput>());
        }
        if (networkObject.IsOwner && !networkObject.IsServer || !networkObject.IsOwner && networkObject.IsServer) //This is for the second player to make each of em look unique
        {
            modelObj.transform.Find("Forward").GetComponent<MeshRenderer>().material = modelObj.GetComponent<MeshRenderer>().material;
            modelObj.GetComponent<MeshRenderer>().material = secondPlayerMat;
        }
    }

    private void Update()
    {

        if (!networkObject.IsOwner) //If the cube is not the client's
        {
            transform.position = networkObject.position;
            transform.rotation = networkObject.rotation;
            return;
        }
        //If the cube is the client's
        //Sending networkObject since that will be sent to other players to update show them who's who
        networkObject.position = transform.position;
        networkObject.rotation = transform.rotation;

    }
}
