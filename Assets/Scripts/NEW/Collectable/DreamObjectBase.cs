using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Quaternion = UnityEngine.Quaternion;

public class DreamObjectBase : DreamObjectBaseBehavior
{
    /*
     * When player touches this send RPC call for whether or not it is a Nightmare or a Dream
     */

    [SerializeField, Tooltip("The tag the player is bound to")]
    protected string playerTag = "Player";

    [SerializeField, Tooltip("How fast the object rotates")]
    protected float rotationSpeed;
    [Space]
    [SerializeField, Tooltip("The chance of becoming a Nightmare"), Range(0,100)]
    protected int nightmareChance;

    [SerializeField, Tooltip("The element number the Nightmare is in the \"Nightmare Object Network Object\" in \"Assets/Bearded Man Studios Inc/Prefabs/NetworkManager\"")]
    protected int nightmareArrayElement = 0;

    [Space]

    [SerializeField, Tooltip("The score to add if this Dream Object is a Dream")]
    protected float score = 1;

    private static readonly int rangeZero = 0;
    private static readonly int rangeHundred = 100;

    private void Update()
    {
        if (networkObject.IsServer)
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up); //Update Speed
            networkObject.rotation = transform.rotation;
        }
        else
        {
            transform.rotation = networkObject.rotation;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(playerTag))
        {
            if (Random.Range(rangeZero, rangeHundred) < nightmareChance) //If can spawn nightmare
            {
                //Spawn nightmare
                //TODO: Fix this since it gives a "Instance not found for a net variable thingy, no idea why it doesn't actually exist, could be something to do with this object itself being instanciated at runtime?
                var nightmare = NetworkManager.Instance.InstantiateNightmareObject(nightmareArrayElement, this.transform.position); //Spawn Nightmare for all players
            }
            else
            {
                //Complete Dream
                collider.GetComponent<ScoreTally>().networkObject.Score += score;
            }
            networkObject.SendRpc(RPC_DESTROY_OBJECT, Receivers.AllBuffered, true);

        }
    }

    public override void DestroyObject(RpcArgs args)
    {
        if (args.GetNext<bool>() == true) //If destroy is called
        {
            DreamsManager.Instance.RemoveDream(this);
            Destroy(this.gameObject);
        }
    }
}
