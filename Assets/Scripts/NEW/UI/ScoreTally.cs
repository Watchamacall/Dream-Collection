using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTally : ScoreTallyBehavior
{
    [SerializeField, Tooltip("The TextMeshProUGUI Instance that is used with setting the Score on screen")]
    protected TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        networkObject.ScoreChanged += ScoreUpdate;
    }

    private void ScoreUpdate(float field, ulong timestep)
    {
        scoreText.text = field.ToString();
    } 
}
