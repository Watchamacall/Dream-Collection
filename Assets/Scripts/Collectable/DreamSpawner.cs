using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Unity;


using Random = UnityEngine.Random;
public class DreamSpawner : DreamSpawnerBehavior
{
    [Tooltip("The GameObject to spawn in as the dreamPrefab")]
    public GameObject dreamPrefab;
    [Tooltip("The MasterDreamCollection instance")]
    private MasterDreamCollection master;
    [Tooltip("The offset to spawn in the Dream Prefab")]
    [SerializeField] private Vector3 dreamObjectOffset = new Vector3(-0.5f, 1, 0);
    [Tooltip("The chance to spawn in the ")]
    [Range(0, 100)]
    [SerializeField] int spawnPercentChance = 50;
    public float minTime, maxTime;
    // Start is called before the first frame update

    void Start()
    {
        master = MasterDreamCollection.ins;

        if (networkObject.IsServer)
        {
            float startTime = Random.Range(0, 10);
            StartCoroutine(SpawnDelay(startTime));
        }
        else
        {
            Destroy(this);
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public void ChanceToSpawn()
    {
        if (transform.childCount == 0 && master.dreams.Count < master.maxDreams)
        {
            int rand = Random.Range(0, 100);

            if (rand < spawnPercentChance)
            {
                networkObject.SendRpc(RPC_SPAWN, Receivers.AllBuffered, true);
            }
        }
    }

    public IEnumerator SpawnDelay(float delayTime)
    {
        float time = 0.0f;

        while (time < delayTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        ChanceToSpawn();
        StartCoroutine(SpawnDelay(Random.Range(minTime, maxTime)));

    }

    public override void Spawn(RpcArgs args)
    {
        //    DreamObjectBehavior temp = null;
        //    //Debug.Log(args.GetNext<bool>());
        //    if (args.GetNext<bool>() == true)
        //    {
        //        temp = NetworkManager.Instance.InstantiateDreamObject();

        //        temp.transform.position = this.transform.position;
        //        temp.transform.parent = this.transform;

        //        //temp.transform.localScale = dreamObjectScale;
        //        temp.transform.localPosition += dreamObjectOffset;

        //        master.Add(temp.GetComponent<DreamObject>());
        //    }
        //}
    }
}
