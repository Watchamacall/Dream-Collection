using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Generated;
using TMPro;
public class MasterDreamCollection : ScoreTallyBehavior
{
    public TextMeshProUGUI textbox;
    public int maxDreams;
    public List<DreamObject> dreams = new List<DreamObject>();
    public static MasterDreamCollection ins;
    private void Awake()
    {
        //Only one instance of this will exist
        if (ins == null)
        {
            ins = this;
        }
    }


    /// <summary>
    /// Adds a <paramref name="listObject"/> to the amount of collectables currently in the build
    /// </summary>
    /// <param name="listObject">The object to add</param>
    public void Add(DreamObject listObject)
    {
        if (dreams.Count < maxDreams)
        {
            dreams.Add(listObject);
        }
    }

    /// <summary>
    /// Checks to see if a collectable can be placed
    /// </summary>
    /// <returns>True is can be spawned, false otherwise</returns>
    public bool CanSpawn()
    {
        return dreams.Count < maxDreams ? true : false;
    }

    private void Update()
    {
        //Making sure textBox is set otherwise can cause errors
        if (textbox == null)
        {
            textbox = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
        textbox.text = $"Score: {(int)networkObject.Score}";
    }

    /// <summary>
    /// Sends the <paramref name="amount"/> to other clients
    /// </summary>
    /// <param name="amount">Number to add to the total score</param>
    public void UpdateScore(float amount)
    {
        networkObject.Score += amount;
    }
}
