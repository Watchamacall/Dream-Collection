using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlsManager : MonoBehaviour
{
    //public static ControlsManager instance;

    public Ground controls;
    private CtrlMode curMode;
    private CtrlMode prevMode;
    public UnityEvent onControlModeChange;

    public CtrlMode CurMode
    {
        get { return curMode; }
    }
    public CtrlMode PrevMode
    {
        get { return prevMode; }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    private void Awake()
    {
        //if (instance != this && instance != null)
        //{
        //    Destroy(this);
        //    return;
        //}
        //instance = this;

        if (controls == null)
        {
            controls = new Ground();
        }
        controls.ConstantControls.Enable();
    }

    public void ChangeControlMode(CtrlMode mode)
    {
        prevMode = curMode;
        curMode = mode;

        switch (curMode)
        {
            case CtrlMode.Play:
                EnterPlayMode();
                break;
            case CtrlMode.Pause:
                EnterPauseMode();
                break;
            default:
                break;
        }
        onControlModeChange?.Invoke();
        Debug.Log($"Changed Control Mode To {curMode}");
    }

    public void EnterPlayMode()
    {
        controls.Move.Enable();
        controls.Look.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void EnterPauseMode()
    {
        controls.Move.Disable();
        controls.Look.Disable();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public enum CtrlMode
    {
        Play,
        Pause,
    }
}
