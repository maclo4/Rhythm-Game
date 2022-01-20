using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using UnityEngine;
using Debug = UnityEngine.Debug;

//using System.Diagnostics.Stopwatch;

public class SongPlayer : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    private double bps;
    private Note currNote;
    private Timer metronome;
    public Metronome metronome2;
    private double msPerBeat;
    public Animator nineRing;
    public GameObject notePrefab;
    private Queue<Note> notes;
    private long previousElapsedMs, currElapsedMs, msSinceLastBeat;
    private static Song song;
    public GameObject songLibrary;
    private float spawnPoint = 6;
    private Stopwatch stopwatch;
    public Animator threeRing;

    private void Awake()
    {
        enabled = false;
        stopwatch = new Stopwatch();
        metronome = new Timer();
        var timer = new Timer();
        //timer.Interval = 1; // 1 milisecond
        // timer.Elapsed += timer_Elapsed;
        //timer.Start();
    }

    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Debug.Log("beep");
        audioSource.enabled = true;
    }

    public void LoadSong(Song _song)
    {
        Debug.Log("Song loaded");
        // implement this later for now just play oblivion every time
        song = _song;
        bps = song.bpm / 60d;
        metronome2.bpm = song.bpm;
        msPerBeat = song.bpm / 60d * 1000d;
        
        animator.speed = (float) msPerBeat / 1000 * 4;
        Debug.Log("msPerBeat: " + msPerBeat + ", bpm: " + song.bpm + ", bps: " + bps + ", interval: " +
                  metronome.Interval);
        song.LoadNotemap(_song.notemapPath);
    }

    //TODO: this method can just be removed probably
    public void PlaySong()
    {
        metronome2.Initialize(song);
        Debug.Log("Oblivion set to true");
        // stopwatch.Start();
        //metronome.Start();

        //songLibrary.SetActive(true);
        // while (stopwatch.ElapsedMilliseconds <= 85) { }

        //audioSource.enabled = true;
        //enabled = true;
    }

    private void Update()
    {


        //Debug.Log("update");
        //currElapsedMs = stopwatch.ElapsedMilliseconds;


        //if ( >= msPerBeat) //currNote.msFromLastNote)
        //{
        //    //EditorApplication.Beep();

        //    Instantiate(notePrefab, new Vector3(spawnPoint, notePrefab.transform.position.y, 0), notePrefab.transform.rotation);
        //    spawnPoint = spawnPoint * -1;
        //}
        // previousElapsedMs
    }
}