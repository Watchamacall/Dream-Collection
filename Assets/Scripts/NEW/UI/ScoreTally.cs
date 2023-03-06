using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTally : ScoreTallyBehavior
{
    [SerializeField, Tooltip("The TextMeshProUGUI Instance that is used with setting the Score on screen")]
    protected TextMeshProUGUI scoreText;
    void Start()
    {
        networkObject.ScoreChanged += ScoreUpdate;
    }

    private void ScoreUpdate(float field, ulong timestep)
    {
        scoreText.text = field.ToString();
    }

    /// <summary>
    /// Sends a RPC call for NewScore and inputs the score to add to the total
    /// </summary>
    /// <param name="scoreToAdd"></param>
    public void UpdateScore(float scoreToAdd)
    {
        networkObject.SendRpc(RPC_NEW_SCORE, Receivers.AllBuffered, scoreToAdd);
    }

    public override void NewScore(RpcArgs args)
    {
        if (networkObject.IsOwner)
        {
            networkObject.Score += args.GetNext<float>();
            scoreText.text = networkObject.Score.ToString();
        }
    }
}
