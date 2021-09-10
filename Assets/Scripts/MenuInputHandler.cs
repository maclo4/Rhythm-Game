using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputHandler : MonoBehaviour
{
    public bool rightButtonStarted, leftButtonStarted, readyToStart, startButtonPressed;
    private void Awake()
    {
        readyToStart = false;
    }
    public void RightBeatpressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Debug.Log("button started");
            rightButtonStarted = true;
        }
        else if (context.duration >= 1)
        {
            //Debug.Log("button cancelled");
            rightButtonStarted = false;
        }
        else if (context.canceled)
        {
            rightButtonStarted = false;
        }
    }
    public void LeftBeatpressed(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Debug.Log("button started");
            leftButtonStarted = true;
        }
        else if (context.duration >= 1)
        {
            //Debug.Log("button cancelled");
            leftButtonStarted = false;
        }
        else if (context.canceled)
        {
            leftButtonStarted = false;
        }
    }
    // TODO: maybe delet
    public void StartButtonPressed(InputAction.CallbackContext context)
    {
        if (readyToStart == true && context.performed == true)
        {

        }
    }
}
