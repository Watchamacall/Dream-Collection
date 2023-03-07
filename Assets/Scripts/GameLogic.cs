using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Unity;
public class GameLogic : MonoBehaviour
{
    /// <summary>
    /// Instanciates Networked Player
    /// </summary>
    void Start()
    {
        NetworkManager.Instance.InstantiatePlayer(0, this.transform.position, this.transform.rotation);
    }
}
