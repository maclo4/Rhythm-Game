using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSongButtonAction : ButtonHandler, IButtonAction
{

    public SongPlayer songPlayer;
    //public ButtonHandler buttonHandler;

    private void Awake()
    {
        buttonAction = this;
    }
    void IButtonAction.ButtonAction()
    {
        songPlayer.PlaySong();
        canvas.SetActive(false);
        Debug.Log("buttonAction");
    }

}
