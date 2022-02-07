using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSongButton : ButtonHandler, IButtonAction
{
    
    //public GameObject chooseASong;
    public SongPlayer songPlayer;
    public Song song;
    public GameObject startSongButton, chooseASong;
    //public ButtonHandler buttonHandler;

    private void Awake()
    {
        buttonAction = this;
        chooseASong = gameObject.transform.parent.transform.parent.gameObject; // jank af but im lazy rn
        startSongButton = GameObject.Find("Canvas");
        startSongButton = startSongButton.transform.Find("Start Button").gameObject; // jank af but liberating after work to write messy code
        songPlayer = GameObject.Find("SCRIPTS").GetComponent<SongPlayer>();
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

