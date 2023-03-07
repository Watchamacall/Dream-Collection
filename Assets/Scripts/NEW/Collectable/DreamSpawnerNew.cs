using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamSpawnerNew : DreamSpawnerBehavior
{
    /*
     * At random intervals, spawn in object and send to Client (Host only has this)
     */

    [SerializeField, Tooltip("The minimum time for a chance to spawn a Dream in")]
        protected int minSpawnTime;
    [SerializeField, Tooltip("The maximum time for a chance to spawn a Dream in")]
        protected int maxSpawnTime;
    [SerializeField, Tooltip("The DreamObject Prefab Element Number in the \"Dream Object Network Object\" in \"Assets/Bearded Man Studios Inc/Prefabs/NetworkManager\"")]
        protected int prefabElementNumber;
    [SerializeField, Tooltip("The chance to spawn a Dream in"), Range(0,100)]
        protected int spawnChance;
    [SerializeField, Tooltip("The object currently spawned in")]
        protected DreamObjectBase spawnedDream;

    private float currentDelayedTime = 0.0f;

    private static readonly int rangeZero = 0;
    private static readonly int rangeHundred = 100;

    /// <summary>
    /// Start the process of spawning in objects if Server, else Destroy script
    /// </summary>
    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (!networkObject.IsServer) //Not host, destroy this script
        {
            Destroy(this.gameObject);
            return;
        }

        StartCoroutine(Delay(Random.Range(minSpawnTime, maxSpawnTime)));

    }

    /// <summary>
    /// Attempts to spawn in a DreamObject
    /// </summary>
    void AttemptSpawn()
    {
        if (networkObject.IsServer)
        {
            if (DreamsManager.Instance.CanAddDream())
            {
                if (Random.Range(rangeZero, rangeHundred) < spawnChance && !spawnedDream)
                {
                    networkObject.SendRpc(RPC_SPAWN, Receivers.AllBuffered, true); //Send a call to Client's that this DreamSpawner is spawning in
                }
            }
        }
    }

    /// <summary>
    /// Delay's function based on the <paramref name="delayTime"/> inputted
    /// </summary>
    /// <param name="delayTime">The time you want to delay</param>
    protected IEnumerator Delay(float delayTime)
    {
        while (currentDelayedTime < delayTime)
        {
            currentDelayedTime += Time.deltaTime;
            yield return null;
        }
        AttemptSpawn();
        currentDelayedTime = 0.0f; //Resetting the count otherwise game go brrrr
        StartCoroutine(Delay(Random.Range(minSpawnTime, maxSpawnTime)));
    }

    /// <summary>
    /// Called when a DreamObject is spawned, only does this if a Server
    /// </summary>
    /// <param name="args"></param>
    public override void Spawn(RpcArgs args)
    {
        if (args.GetNext<bool>() == true && networkObject.IsServer) //If this can spawn an object in
        {
            spawnedDream = NetworkManager.Instance.InstantiateDreamObjectBase(prefabElementNumber, this.transform.position, this.transform.rotation).GetComponent<DreamObjectBase>(); //Spawn in object at location
            DreamsManager.Instance.AddDream(spawnedDream);
        }
    }
}
