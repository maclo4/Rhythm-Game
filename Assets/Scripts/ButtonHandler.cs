using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public interface IButtonAction 
{
    void ButtonAction(); 
}
public class ButtonHandler : MonoBehaviour
{
    public IButtonAction buttonAction = null;
    public GameObject canvas;
    //public MenuInputHandler menuInput;
    bool buttonSelected;
    bool rightBeatPressed, leftBeatPressed, rightBeatStarted, leftBeatStarted, rightBeatStartedLastFrame;
    // public GameObject canvas;
    Collider2D leftCursor, rightCursor;

    private void Awake()
    {
        //this.GetComponent<Rigidbody2D>().sleepMode = RigidbodySleepMode2D.NeverSleep;
    }
    void OnTriggerStay2D(Collider2D colider)
    {
        //Debug.Log(menuInput.rightButtonStarted);


        if ((colider.tag == "Left Cursor" && MenuInputHandler.leftButtonStarted) || (colider.tag == "Right Cursor" && MenuInputHandler.rightButtonStarted))  
        {
            if (MenuInputHandler.leftButtonStarted == true)
            {
                MenuInputHandler.leftButtonStarted = false;
            }
            else if (MenuInputHandler.rightButtonStarted == true)
            {
                MenuInputHandler.rightButtonStarted = false;
            }

            Debug.Log("button disabled");
           // canvas.SetActive(false);
            buttonAction?.ButtonAction();
        }
       
    }

    public void SetButtonAction(IButtonAction _buttonAction)
    {
        buttonAction = _buttonAction;
    }


}

/*
 * Example how to implement this class
 * public class EasyButtonAction : ButtonHandler, IButtonAction
{
    //public ButtonHandler buttonHandler;

    private void Awake()
    {
        buttonAction = this;
    }
    void IButtonAction.ButtonAction() {
        Debug.Log("buttonAction");
    }
    
}
*/