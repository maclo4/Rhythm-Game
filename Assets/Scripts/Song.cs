using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public enum Ring {one, two, three}

public class Song : MonoBehaviour
{

    public string notemapPath = "Assets/Song_Files/Oblivion.notemap";
    public string title, artist;
    public int bpm;
    public float offset;

    public RingObject rings;
    public int[] rings2 = new int[1000];
    //public NoteArray[] rings3 = new NoteArray[100];

    private float animationSpeed;
    //public Animator nineRing, threeRing, fourRing, sixRing, sevenRing, eightRing, tenRing, twelveRing, oneRing; 
    private int currNote = 0;
    public Ring[] ring4 = new Ring[100];
    public int[,] rings3 = new int[100,16];// = new int[100,16];
    private List<int> noteMap = new List<int>();

    //void OnGUI()
    //{

    //    // Starts a horizontal group
    //    GUILayout.BeginHorizontal("box");

    //    for(int i = 0; i < rings2.Length;  i++ ) {
    //        rings2[i] = EditorGUILayout.IntField(rings2[i]);
    //    }
    //    GUILayout.EndHorizontal();
    //}



    public void Awake()
    {
        rings.setAnimationSpeed(60f / bpm * 2);
        animationSpeed = 60f / bpm * 2;
        LoadSong();
    }

    private void LoadSong()
    {
        Debug.Log("laod song");
        try
        {
            if (File.Exists(notemapPath))
            {
                Debug.Log("Song Exists!");
            }

            using (StreamReader sr = new StreamReader(notemapPath))
            {
                Debug.Log("peek: " + sr.Peek());
                while (sr.Peek() >= 0)
                {
                    char temp = Convert.ToChar(sr.Read());
                    if (temp != ' ' && temp != '\n' && temp != '\r')
                    {
                        Debug.Log(temp);
                        noteMap.Add((int)char.GetNumericValue(temp));
                    }


                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The process failed: " + e.Message);
        }
    }
    private void PlayNote(GameObject note)
    {
        GameObject prefab = Instantiate(note);
        if(prefab.TryGetComponent(out Animator animator))
        {
            animator.speed = animationSpeed;
            animator.SetTrigger("playNote");
        }

    }
    public void NextNote()
    {
        if(currNote < noteMap.Count)
        {
            switch (noteMap[currNote])
            {
                case 8:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.twelveRingPrefab);
                    });
                    break;
                case 9:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.oneRingPrefab);
                    });
                    break;
                case 6:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.threeRingPrefab);
                    });
                    break;
                case 3:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.fourRingPrefab);
                    });
                    break;
                case 2:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.sixRingPrefab);
                    });
                    break;
                case 1:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.sevenRingPrefab);
                    });
                    break;
                case 4:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.nineRingPrefab);
                    });
                    break;
                case 7:
                    UnityThread.executeInUpdate(() =>
                    {
                        PlayNote(rings.tenRingPrefab);
                    });
                    break;
            }

            currNote++;
        }
        //if (currNote == 0)
        //{
        //    UnityThread.executeInUpdate(() =>
        //    {
        //        PlayNote(rings.nineRingPrefab);
        //    });
        //    currNote = 1;
        //}

        //else if (currNote == 1)
        //{
        //    UnityThread.executeInUpdate(() =>
        //    {
        //        PlayNote(rings.threeRingPrefab);
        //    });
        //    currNote = 2;
        //}
        //else if (currNote == 2)
        //{
        //    UnityThread.executeInUpdate(() =>
        //    {
        //        PlayNote(rings.fourRingPrefab);
        //    });
        //    currNote = 0;
        //}
        //else if (currNote == -1)
        //{

        //}
    }
}
