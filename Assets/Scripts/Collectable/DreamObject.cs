using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;

public class DreamObject : DreamObjectBehavior
{
    MasterDreamCollection master;

    [Range(0,100)]
    [SerializeField] private int scoreChance;
    [SerializeField] private GameObject nightmare;
    [SerializeField] private float scoreAdd;

    Vector3 startPos;
    private void Start()
    {
        master = MasterDreamCollection.ins;
        startPos = transform.position;
    }

    private void LateUpdate()
    {
        if (transform.position != startPos)
        {
            transform.position = startPos;
        }
    }

    /// <summary>
    /// Destorys the Dream element and adds to the scoreboard
    /// </summary>
    [ContextMenu("Dream Destroy")]
    public void DreamDestory()
    {
        //Set the destruction of the Dream object, allowing for it to be spawned in again
        master.dreams.Remove(this);
        master.UpdateScore(scoreAdd);
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Spawns in the Nightmare enemy and destorys the Dream
    /// </summary>
    [ContextMenu("Nightmare Destory")]
    public void NightmareSpawn()
    {
        master.dreams.Remove(this);
        GameObject.Instantiate(nightmare, this.transform.position, nightmare.transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float rand = Random.Range(0, 100);
            networkObject.SendRpc(RPC_NIGHTMARE, Receivers.AllBuffered, rand < scoreChance ? false : true);
        }
    }

    /// <summary>
    /// Spawns in a Nightmare or Destorys the dream based on <paramref name="args"/>
    /// </summary>
    /// <param name="args">Arguments recieved through RPC</param>
    public override void Nightmare(RpcArgs args)
    {
        //Next element
        if (args.GetNext<bool>())
            NightmareSpawn();
        else
            DreamDestory();
    }

}
