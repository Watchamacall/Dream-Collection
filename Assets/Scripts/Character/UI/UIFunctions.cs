using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeardedManStudios.Forge.Networking.Unity;
using UnityEngine.SceneManagement;
public class UIFunctions : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject pauseCanvas;
    public GameObject optionsCanvas;
    ControlsManager manager;

    private void OnEnable()
    {
        manager = GameObject.Find("GameLogic").GetComponent<ControlsManager>();
        manager.controls.ConstantControls.Pause.performed += context => ControlModeChange();
    }
    private void OnDisable()
    {
        manager.controls.ConstantControls.Pause.performed -= context => ControlModeChange();
    }

    public void ControlModeChange()
    {
        if (manager.CurMode == ControlsManager.CtrlMode.Pause)
        {
            manager.ChangeControlMode(ControlsManager.CtrlMode.Play);
        }
        else
        {
            manager.ChangeControlMode(ControlsManager.CtrlMode.Pause);
        }
    }

    public void Resume()
    {
        manager.ChangeControlMode(ControlsManager.CtrlMode.Play);
        //TODO: Close the canvas and open the other canvas
    }

    public void CanvasChange()
    {
        pauseCanvas.SetActive(!pauseCanvas.activeSelf);
        optionsCanvas.SetActive(!optionsCanvas.activeSelf);
        //TODO: Open the canvas1 and close the canvas2
    }

    public void Leave()
    {
        //TODO: Leave the match
        NetworkManager.Instance.Disconnect();
        Destroy(this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
