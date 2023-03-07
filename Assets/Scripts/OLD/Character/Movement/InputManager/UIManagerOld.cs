using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerOld : MonoBehaviour
{
    public GameObject playCanvas;
    public GameObject pauseCanvas;
    public GameObject optionsCanvas;
    ControlsManager manager;
    private void OnEnable()
    {
        manager = GameObject.Find("GameLogic").GetComponent<ControlsManager>();
        manager.onControlModeChange.AddListener(OnUIChange);
    }
    private void OnDisable()
    {
        manager.onControlModeChange.RemoveListener(OnUIChange);
    }

    public void OnUIChange()
    {
        switch (manager.CurMode)
        {
            case ControlsManager.CtrlMode.Play:
                playCanvas.SetActive(true);
                pauseCanvas.SetActive(false);
                optionsCanvas.SetActive(false);
                break;
            case ControlsManager.CtrlMode.Pause:
                playCanvas.SetActive(false);
                pauseCanvas.SetActive(true);
                optionsCanvas.SetActive(false);
                break;
            default:
                break;
        }
    }
}
