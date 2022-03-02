using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.Serialization;

public class SongMenuList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] menuSlots = new GameObject[3];
    [FormerlySerializedAs("SongMenuParent")] 
    public GameObject songMenuParent;
    public GameObject menuSongPrefab;
    private int mostRecentSongIndex;

    private void Start()
    {
        Debug.Log("Directory: " + Directory.GetCurrentDirectory());
        LoadSongMenu();
    }

    private void LoadSongMenu()
    {
        Debug.Log("Directory: " + Directory.GetCurrentDirectory());
        var songFilePaths = Directory.GetFiles("Assets/Song_Files/", "*.notemap");
        foreach(var song in songFilePaths)
        {
            Debug.Log(song);
        }
        
        /*var i = 0;
        while(i < songFilePaths.Length || i < 3)
        {
            var menuSongGameObject = Instantiate(menuSongPrefab, menuSlots[i].transform);
            var songNameUIComponent = menuSongGameObject.GetComponentInChildren<TextMeshProUGUI>();
            var songScript = menuSongGameObject.GetComponent<Song>();
            songScript.LoadSongMetaData(songFilePaths[i]);
            if (songNameUIComponent != null)
            {
                songNameUIComponent.text = songScript.title;
            }
            i++;
        }*/

        songMenuParent.SetActive(true);
        
        var previousSong = songMenuParent.transform;
        foreach (var songFilePath in songFilePaths)
        {
            var menuSong = Instantiate(menuSongPrefab, previousSong);
            menuSong.transform.Translate(previousSong.position);
            menuSong.transform.Translate(0,-1,0);
            var songName = menuSong.GetComponentInChildren<TextMeshProUGUI>();
            var songScript = menuSong.GetComponent<Song>();
            songScript.LoadSongMetaData(songFilePath);
            if (songName != null)
            {
                songName.text = songScript.title;
            }

            previousSong = menuSong.transform;
        }
    }

}
