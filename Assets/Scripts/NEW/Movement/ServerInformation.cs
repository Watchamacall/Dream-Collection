using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServerInformation : PlayerBehavior
{
    /*
     * Sends any relevant information to the other clients
     */

    int playerNo;
    public string playerName;
    public Color playerColour;

    protected override void NetworkStart()
    {
        base.NetworkStart();

        //TODO: Destory any objects that aren't needed for other Client's, set player number, name and colour

    }

    /// <summary>
    /// Leaves the game and set's scene to connection screen
    /// </summary>
    public void LeaveGame()
    {
        NetworkManager.Instance.Disconnect();
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
