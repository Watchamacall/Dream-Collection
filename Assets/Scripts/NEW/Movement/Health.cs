using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XInput;
using UnityEngine.UI;

public class Health : HealthBehavior
{
    /*
     * Holds the Health of the Client and allows for easy Setting and Getting of Health
     */

    [SerializeField, Tooltip("The maximum health the player has")]
    protected int maxHealth = 10;
    
    [Space]

    [SerializeField, Tooltip("The slider representing the Health of the user")]
    protected Slider healthSlider;
    #region Health Get Set
    /// <summary>
    /// Returns the currentHealth
    /// </summary>
    /// <returns>Current Health of this Client</returns>
    public float GetHealth()
    {
        return networkObject.health;
    }

    /// <summary>
    /// Set's the Health of this Client
    /// </summary>
    /// <param name="value">The value to add to the Client</param>
    public void SetHealth(float value)
    {
        networkObject.SendRpc(RPC_HEALTH_CHANGED, Receivers.AllBuffered, value);
    }
    #endregion

    /// <summary>
    /// Overridden to set the Slider's maxValue and Set Health of the Client to the maxHealth
    /// </summary>
    protected override void NetworkStart()
    {
        base.NetworkStart();

        healthSlider.maxValue = maxHealth;
        SetHealth(maxHealth);
    }

    /// <summary>
    /// Display's the death screen for the Owner
    /// </summary>
    private void KillPlayer()
    {
        if (networkObject.IsOwner) //Only do this if Owner
        {
            GetComponent<UIManager>().SetCanvas(EUIUnique.CANVAS_Dead);
            GetComponent<ClientController>().InputController.Movement.Disable();
        }
    }

    /// <summary>
    /// RPC called when SetHealth is activated
    /// </summary>
    /// <param name="args">0 is health to be added</param>
    public override void HealthChanged(RpcArgs args)
    {
        networkObject.health = Mathf.Clamp(networkObject.health + args.GetNext<float>(), 0.0f, maxHealth);

        healthSlider.value = networkObject.health;

        if (networkObject.health <= 0.0f)
        {
            KillPlayer();
        }
    }
}
