using BeardedManStudios.Forge.Networking.Generated;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.XInput;

//Enum for elements in the UI, match them to the number of elements you will have in the array
public enum EUIUnique
{
    CANVAS_Main,
    CANVAS_Pause,
    CANVAS_Options,
    CANVAS_Dead,
}

[System.Serializable]
public struct FUIElement
{
    public Canvas canvas;
    public bool pauseWorld;
    public EUIUnique ui_Enum;
}
public class UIManager : MonoBehaviour
{
    [Tooltip("The canvases that are in the game")]
    public FUIElement[] canvases;

    public EUIUnique startCanvasEnum;

    public UnityEvent pauseGame;
    public UnityEvent playGame;

    protected Canvas currentCanvas;

    public ClientController clientController;

    /// <summary>
    /// Sets the <paramref name="canvasToSet"/> as the main Canvas active
    /// </summary>
    /// <param name="canvasToSet">The Canvas to be the main one active</param>
    public void SetCanvas(Canvas canvasToSet)
    {
        foreach (FUIElement ui_Element in canvases)
        {
            Canvas canvas = ui_Element.canvas;

            if (canvasToSet == canvas)
            {
                canvas.gameObject.SetActive(true);

                currentCanvas = canvas;

                CanPauseWorld(ui_Element.pauseWorld);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }

    public void SetCanvas(EUIUnique ui_Unique)
    {
        SetCanvas(canvases.Where(canvas => canvas.ui_Enum == ui_Unique).First().canvas);
    }

    /// <summary>
    /// Returns the UIElement which <paramref name="currentCanvas"/> is being held in
    /// </summary>
    /// <param name="currentCanvas">The canvas you want the UIElement from</param>
    /// <returns>The UIElement <paramref name="currentCanvas"/> is being held in</returns>
    public FUIElement CurrentCanvas(Canvas currentCanvas)
    {
        return canvases.Where(canvas => canvas.canvas == currentCanvas).First();
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
    public void GamePaused()
    {
        if (CurrentCanvas(currentCanvas).pauseWorld)
            playGame.Invoke();
        else
            pauseGame.Invoke();
    }
}
