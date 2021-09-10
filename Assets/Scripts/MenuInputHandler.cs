using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuInputHandler : MonoBehaviour
{
    public static bool rightButtonStarted, leftButtonStarted, readyToStart, startButtonPressed;

    private static void Awake()
    {
        readyToStart = false;
    }
    public static void RightBeatpressed(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            Debug.Log("button started");
            rightButtonStarted = true;
        }
        else if (context.performed == false)
        {
            Debug.Log("button cancelled");
            rightButtonStarted = false;
        }
        else if (context.canceled)
        {
            rightButtonStarted = false;
        }
    }
    public static void LeftBeatpressed(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            Debug.Log("button started");
            leftButtonStarted = true;
        }
        else if (context.performed == false)
        {
            Debug.Log("button cancelled");
            leftButtonStarted = false;
        }
        else if (context.canceled)
        {
            leftButtonStarted = false;
        }
    }
    // TODO: maybe delet
    public static void StartButtonPressed(InputAction.CallbackContext context)
    {
        if (readyToStart == true && context.performed == true)
        {

        }
    }
}
