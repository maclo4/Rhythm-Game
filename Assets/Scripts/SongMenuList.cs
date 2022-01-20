using UnityEngine;
using System.IO;
using TMPro;

public class SongMenuList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] menuSlots = new GameObject[3];
    public GameObject menuSongPrefab;
    private int mostRecentSongIndex;

    private void Start()
    {
        Debug.Log("Directory: " + Directory.GetCurrentDirectory());
        LoadSongMenu();
    }

    public void LoadSongMenu()
    {
        Debug.Log("Directory: " + Directory.GetCurrentDirectory());
        var songs = Directory.GetFiles("Assets/Song_Files/", "*.notemap");
        foreach(var song in songs)
        {
            Debug.Log(song);
        }
        
        var i = 0;
        while(i < songs.Length || i < 3)
        {
            var menuSong = Instantiate(menuSongPrefab, menuSlots[i].transform);
            var songName = menuSong.GetComponentInChildren<TextMeshProUGUI>();
            var song = menuSong.GetComponent<Song>();
            song.LoadSongMetaData(songs[i]);
            if (songName != null)
            {
                songName.text = song.title;
            }
            i++;
        }
    }

}
