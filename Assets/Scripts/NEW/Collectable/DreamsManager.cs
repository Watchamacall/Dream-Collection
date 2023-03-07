using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamsManager : MonoBehaviour
{
    /*
     * Handles all the spawned in Dreams and stores them to be accessed and checked around (Host Only)
     */

    #region Instance
    protected static DreamsManager instance;
    public static DreamsManager Instance { get { return instance; } }
    #endregion

    [SerializeField, Tooltip("The DreamObjects in the world")]
    protected List<DreamObjectBase> dreamObjects;
    
    [SerializeField, Tooltip("The maximum dream objects that can exist in the world at one time")]
    protected int maxDreamCount;

    /// <summary>
    /// Creates the Instance otherwise Destroys itself
    /// </summary>
    private void OnEnable()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    /// <summary>
    /// Adds a dream to the dreamObjects list
    /// </summary>
    /// <param name="spawnedDreamObject">The object you are attempting to add</param>
    public void AddDream(DreamObjectBase spawnedDreamObject)
    {
        dreamObjects.Add(spawnedDreamObject);
    }

    /// <summary>
    /// Removes a dream to the dreamObjects list
    /// </summary>
    /// <param name="spawnedDreamObject">The object you are attempting to remove</param>
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
