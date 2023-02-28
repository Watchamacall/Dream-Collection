using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Canvas currentCanvas;

    private ClientController clientController;

    // Start is called before the first frame update
    void Start()
    {
        clientController = GetComponent<ClientController>();
        SetCanvas(startCanvas);
    }

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
}
