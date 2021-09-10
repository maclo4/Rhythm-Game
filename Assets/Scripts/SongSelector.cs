using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelector : ButtonHandler, IButtonAction
{
    
    //public GameObject chooseASong;
    public SongPlayer songPlayer;
    public Song song;
    public GameObject startSongButton, chooseASong;
    //public ButtonHandler buttonHandler;

    private void Awake()
    {
        buttonAction = this;
    }
    void IButtonAction.ButtonAction()
    {
        songPlayer.LoadSong(song);

        startSongButton.SetActive(true);
        chooseASong.SetActive(false);
        //canvas.readyToStart = true;
        //canvas.SetActive(false);
        
        Debug.Log("buttonAction");
    }

}

