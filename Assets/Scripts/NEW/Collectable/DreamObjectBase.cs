using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField, Tooltip("The multiplier that will be added onto this object when a player touches it")]
    protected float touchSpinMultiplier;
    [SerializeField, Tooltip("The rotationSpeed that will cause either a dream score to be added or a nightmare to spawn")]
    protected float spinFinishSpeed;

    [SerializeField, Tooltip("The element number the Nightmare is in the \"Nightmare Object Network Object\" in \"Assets/Bearded Man Studios Inc/Prefabs/NetworkManager\"")]
    protected int nightmareArrayElement = 0;

    [Space]

    [SerializeField, Tooltip("The score to add if this Dream Object is a Dream")]
    protected float score = 1;

    [Space]
    //Static Members for ints
    private static readonly int rangeZero = 0;
    private static readonly int rangeHundred = 100;

    private void Update()
    {
        if (networkObject.IsServer) //Only turning on the Server, keeps the rotation the same
        {
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up); //Update Speed
            networkObject.rotation = transform.rotation;
        }
        else
        {
            transform.rotation = networkObject.rotation;
        }
    }
    /// <summary>
    /// When an Owner steps into the trigger, send RPC
    /// </summary>
    /// <param name="collider">The Owner which has stepped into it</param>
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag(playerTag))
        {
            networkObject.SendRpc(RPC_PLAYER_HIT, Receivers.Server);
        }
    }

    /// <summary>
    /// Spins up the Object until it a certain point is reached, will either spawn Nightmare or Dream otherwise
    /// </summary>
    /// <returns></returns>
    public IEnumerator SpinUp()
    {
        while (rotationSpeed < spinFinishSpeed) //Spin faster until spinFinishSpeed has been reached
        {
            rotationSpeed += touchSpinMultiplier * Time.deltaTime;
            yield return null;
        }

        if (Random.Range(rangeZero, rangeHundred) < nightmareChance) //If Nightmare can spawn
        {
            var nightmare = NetworkManager.Instance.InstantiateNightmareObject(nightmareArrayElement, this.transform.position); //Spawn Nightmare for all players, set to this DreamObjectBase's position
        }
        else //Only a Dream
        {
            Score.Instance.UpdateScore(score);
        }
        networkObject.SendRpc(RPC_DESTROY_OBJECT, Receivers.AllBuffered, true);
    }

    /// <summary>
    /// RPC call to destroy this Object on all Client's
    /// </summary>
    /// <param name="args">1 is whether or not to destroy this Object</param>
    public override void DestroyObject(RpcArgs args)
    {
        if (args.GetNext<bool>() == true && networkObject.IsServer) //Only remove from the DreamsManager if Server
        {
            DreamsManager.Instance.RemoveDream(this);
        }
        Destroy(this.gameObject);
    }

    /// <summary>
    /// RPC call to start the spinup process of the Object
    /// </summary>
    /// <param name="args">N/A</param>
    public override void PlayerHit(RpcArgs args)
    {
        if (networkObject.IsServer) //Only the server will activate the Coroutine, keeps everybody on the same rotation
        {
            StartCoroutine(SpinUp());
        }
    }
}
