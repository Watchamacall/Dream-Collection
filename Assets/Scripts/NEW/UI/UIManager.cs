using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XInput;

[System.Serializable]
public struct UIElement
{
    public Canvas canvas;
    public bool pauseWorld;

}
public class UIManager : MonoBehaviour
{
    [Tooltip("The canvases that are in the game")]
    public UIElement[] canvases;

    public Canvas startCanvas;

    public UnityEvent pauseGame;
    public UnityEvent playGame;

    private Canvas currentCanvas;

    private ClientController clientController;

    // Start is called before the first frame update
    void Start()
    {
        clientController = GetComponent<ClientController>();
        clientController.InputController.Constant.Pause.performed += context => GamePaused();

        SetCanvas(startCanvas);
    }

    /// <summary>
    /// Sets the <paramref name="canvasToSet"/> as the main Canvas active
    /// </summary>
    /// <param name="canvasToSet">The Canvas to be the main one active</param>
    public void SetCanvas(Canvas canvasToSet)
    {
        foreach (UIElement ui_Element in canvases)
        {
            Canvas canvas = ui_Element.canvas;

            if (canvasToSet == canvas)
            {
                canvas.enabled = true;

                currentCanvas = canvas;

                CanPauseWorld(ui_Element.pauseWorld);
            }
            else
            {
                canvas.enabled = false;
            }
        }
    }

    /// <summary>
    /// Returns the UIElement which <paramref name="currentCanvas"/> is being held in
    /// </summary>
    /// <param name="currentCanvas">The canvas you want the UIElement from</param>
    /// <returns>The UIElement <paramref name="currentCanvas"/> is being held in</returns>
    public UIElement CurrentCanvas(Canvas currentCanvas)
    {
        foreach (UIElement element in canvases)
        {
            if (element.canvas == currentCanvas)
            {
                return element;
            }
        }
        return new UIElement();
    }

    /// <summary>
    /// using <paramref name="pauseWorld"/>, either makes the mouse visible or not
    /// </summary>
    /// <param name="pauseWorld">Whether or not the Canvas can pause the world</param>
    public void CanPauseWorld(bool pauseWorld) 
    {
        if (pauseWorld)
        {
            clientController.InputController.Movement.Disable();
            clientController.InputController.Look.Disable();

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            clientController.InputController.Movement.Enable();
            clientController.InputController.Look.Enable();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    /// <summary>
    /// Called when the pause button has been pressed, either invokes playGame or pauseGame Unity Events
    /// </summary>
    protected void GamePaused()
    {
        Debug.Log("Called Function!");
        if (CurrentCanvas(currentCanvas).pauseWorld)
        {
            playGame.Invoke();
        }
        else
        {
            pauseGame.Invoke();
        }
    }
}
