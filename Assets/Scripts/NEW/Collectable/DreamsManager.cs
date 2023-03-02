using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamsManager : MonoBehaviour
{
    /*
     * Handles all the spawned in Dreams and stores them to be accessed and checked around (Host Only)
     */

    public static DreamsManager instance;

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
    /// Returns true if it can spawn in the object and spawns it in otherwise returns false
    /// </summary>
    /// <param name="dreamObject">The object you are trying to spawn in</param>
    /// <returns></returns>
    public bool TryAddDream(DreamObjectBase dreamObject)
    {
        if (CanAddDream())
        {
            dreamObjects.Add(dreamObject);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns true if you can Add a dream to the DreamObjects List
    /// </summary>
    /// <returns>True if can spawn object in, false otherwise</returns>
    protected bool CanAddDream()
    {
        return dreamObjects.Count < maxDreamCount;
    }
}
