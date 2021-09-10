using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    public GameObject leftCursor;
    public GameObject rightCursor;
    public Song song;
    // Start is called before the first frame update
    void Start()
    {
        InputSystem.pollingFrequency = 400;
    }

    public void MoveLeftCursor(InputAction.CallbackContext context)
    {
        leftCursor.transform.position = context.ReadValue<Vector2>() * 6.8f;
    }
    public void MoveRightCursor(InputAction.CallbackContext context)
    {
        rightCursor.transform.position = context.ReadValue<Vector2>() * 6.8f;
    }
    public void RightBeatHit(InputAction.CallbackContext context)
    {
        //if(context.)
    }
        // Update is called once per frame
    void Update()
    {
        
    }
}
