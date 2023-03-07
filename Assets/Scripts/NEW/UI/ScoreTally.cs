using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTally : MonoBehaviour
{
    [SerializeField, Tooltip("The TextMeshProUGUI Instance that is used with setting the Score on screen")]
    protected TextMeshProUGUI scoreText;

    /// <summary>
    /// Set's the Client's UI to display the correct text if changed
    /// </summary>
    private void FixedUpdate()
    {
        if (Score.Instance.networkObject.Score != float.Parse(scoreText.text))
        {
            scoreText.text = Score.Instance.networkObject.Score.ToString();
        }
    }
}
