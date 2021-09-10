using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyButtonAction : ButtonHandler, IButtonAction
{
    public GameObject selectDifficulty;
    public GameObject chooseASong;
    //public ButtonHandler buttonHandler;

    private void Awake()
    {
        buttonAction = this;
    }
    void IButtonAction.ButtonAction() {

        selectDifficulty.SetActive(false);
        chooseASong.SetActive(true);
        Debug.Log("buttonAction");
    }
    
}
