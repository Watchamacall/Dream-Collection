using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamsManager : MonoBehaviour
{
    /*
     * Handles all the spawned in Dreams and stores them to be accessed and checked around (Host Only)
     */

    protected static DreamsManager instance;
    public static DreamsManager Instance { get { return instance; } }

    [SerializeField, Tooltip("The DreamObjects in the world")]
    protected List<DreamObjectBase> dreamObjects;
    
    [SerializeField, Tooltip("The maximum dream objects that can exist in the world at one time")]
    protected int maxDreamCount;

    private void OnEnable()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Returns true if it can spawn in the object otherwise returns false
    /// </summary>
    /// <param name="spawnedDreamObject">The object you are trying to spawn in</param>
    /// <returns></returns>
    public void AddDream(DreamObjectBase spawnedDreamObject)
    {
        dreamObjects.Add(spawnedDreamObject);
    }

    public void RemoveDream(DreamObjectBase spawnedDreamObject)
    {
        dreamObjects.Remove(spawnedDreamObject);
    }

    /// <summary>
    /// Returns true if you can Add a dream to the DreamObjects List
    /// </summary>
    /// <returns>True if can spawn object in, false otherwise</returns>
    public bool CanAddDream()
    {
        return dreamObjects.Count < maxDreamCount;
    }
}
