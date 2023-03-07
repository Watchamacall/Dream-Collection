using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : ScoreTallyBehavior
{
    [SerializeField, Tooltip("The total score of Client's stored locally")]
    private float localScore;

    [Tooltip("Local instance of this Object, can only have one in scene at a time")]
    protected static Score instance;

    //Get function for the protected variable
    public static Score Instance
    {
        get { return instance; }
    }

    /// <summary>
    /// Set's up the instance on NetworkStart
    /// </summary>
    protected override void NetworkStart()
    {
        base.NetworkStart();

        if (instance == null)
        {
            instance = this;
        }
    }

    /// <summary>
    /// Called when updating the score. Sends RPC to allow for all client's to be kept up to date
    /// </summary>
    /// <param name="scoreToAdd">Value to add to the Score</param>
    public void UpdateScore(float scoreToAdd)
    {
        networkObject.Score += scoreToAdd;
        networkObject.SendRpc(RPC_NEW_SCORE, Receivers.AllBuffered);
    }

    /// <summary>
    /// RPC call for updating the Client on the current score
    /// </summary>
    /// <param name="args">N/A</param>
    public override void NewScore(RpcArgs args)
    {
        localScore = networkObject.Score;
        Debug.Log($"Score now is {networkObject.Score}");
    }
}
