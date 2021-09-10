using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class SongMenuList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] menuSlots = new GameObject[3];
    public GameObject menuSongPrefab;
    private int mostRecentSongIndex;
    void Start()
    {
        Debug.Log("Directory: " + Directory.GetCurrentDirectory());
        LoadSongMenu();
    }

    public void LoadSongMenu()
    {
        string[] songs = Directory.GetFiles("Assets/Song_Files/", "*.notemap");
        foreach(string song in songs)
        {
            Debug.Log(song);
        }
        int i = 0;
        while(i < songs.Length || i < 3)
        {
            GameObject menuSong = Instantiate(menuSongPrefab, menuSlots[i].transform);
            if(menuSong.TryGetComponent<TMPro.TextMeshProUGUI>(out TMPro.TextMeshProUGUI songName))
            {
                songName.text = songs[i];
            }
            //menuSong.GetComponentsInChildren<TextMeshProUGUI>(out TextMeshProUGUI healthText);
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
