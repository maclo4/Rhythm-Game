using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Song : MonoBehaviour
{

    public string notemapPath = "Assets/Song_Files/Oblivion.notemap";
    public string title, artist;
    public int bpm;
    public float offset;

    public RingObject rings;

    private float animationSpeed;
    private int currNote = 0;
    //private readonly List<int> m_NoteMap = new List<int>();
    private readonly List<Cursor> cursor = new List<Cursor>();
    private readonly List<Note> noteMap = new List<Note>();
    private static readonly int PlayNote1 = Animator.StringToHash("playNote");
    private static readonly int PlayLeftNote = Animator.StringToHash("playLeftNote");
    private static readonly int PlayRightNote = Animator.StringToHash("playRightNote");

    public void Awake()
    {
        //rings.setAnimationSpeed(60f / bpm * 2);
        animationSpeed = 60f / bpm;
        //LoadSong();
    }

    public void LoadNotemap(string path)
    {
        Debug.Log("load song");
        try
        {
            if (File.Exists(path))
            {
                Debug.Log("Song Exists!");
            }
            
            using var sr = new StreamReader(path);
            var line = sr.ReadLine();
            while(line != null && (line.Contains("Artist") || line.Contains("Title") ||
                                   line.Contains("Bpm") || line.Contains("Offset")))
            {
                line = sr.ReadLine();
            }
            
            while (sr.Peek() >= 0)
            { 
                var noteDirection = Convert.ToChar(sr.Read());
                if (noteDirection == ' ' || noteDirection == '\n' || noteDirection == '\r') continue;

                if ((int) char.GetNumericValue(noteDirection) == 0)
                {
                    noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                    continue;
                }
                if (sr.Peek() < 0)
                {
                    noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                    continue;
                }

                var cursorDirection = Convert.ToChar(sr.Read());
                if (cursorDirection == ' ' && cursorDirection == '\n' && cursorDirection == '\r') continue;
                
                switch (cursorDirection)
                {
                    case 'L':
                    case 'l':
                        noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Left));
                        break;
                    case 'R':
                    case 'r':
                        noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Right));
                        break;
                    case 'N':
                    case 'n':
                        noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                        break;
                    default:
                        if (char.IsDigit(cursorDirection))
                        {
                            noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                            noteMap.Add(new Note((int)char.GetNumericValue(cursorDirection), Cursor.Neutral));
                        }
                        else
                        {
                            noteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                        }
                        break;
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log("The process failed: " + e.Message);
        }
    }

    public void LoadSongMetaData(string path)
    {
        foreach (var line in File.ReadAllLines(path))
        {
            if (line.Contains("Artist: "))
            {
                artist = line;
                artist = artist.Replace("Artist: ", "");
            }
            if (line.Contains("Title: "))
            {
                title = line;
                title = title.Replace("Title: ", "");
            }
            if (line.Contains("Bpm: "))
            {
                var bpmString = line;
                bpmString = bpmString.Replace("Bpm: ", "");
                bpm = int.Parse(bpmString);
            }
            if (line.Contains("Offset: "))
            {
                var offsetString = line;
                offsetString = offsetString.Replace("Offset: ", "");
                offset = float.Parse(offsetString);
            }
            
        }
    }
    private void PlayNote(GameObject note, Cursor cursorType)
    {
        var prefab = Instantiate(note);
        
        if (!prefab.TryGetComponent(out Animator animator)) return;
        animator.speed = animationSpeed;
        
        var spriteRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = new Color(255f, 131f, 131f, 255f);

        //if (!prefab.TryGetComponent(out NoteController noteController)) return;
        //noteController.cursor = cursorType;
        
        if (cursorType == Cursor.Left)
        {
            spriteRenderer.material.color = new Color(1f, 131f / 255, 131f / 255, 1f);
            animator.SetTrigger(PlayLeftNote);
        }
        else if (cursorType == Cursor.Right)
        {
            spriteRenderer.material.color = new Color(0f, 1f, 1f, 1f);
            animator.SetTrigger(PlayRightNote);
        }
        else if (cursorType == Cursor.Neutral)
        {
            spriteRenderer.material.color = new Color(0f, 1f, 1f, 1f);
            animator.SetTrigger(PlayNote1);
        }

        //animator.SetTrigger(PlayNote1);

    }
    public void NextNote()
    {
        if (currNote >= noteMap.Count) return;

        Cursor tempCursor;
        switch (noteMap[currNote].noteDirection)
        {
            case 8:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.twelveRingPrefab, tempCursor);
                });
                break;
            case 9:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.oneRingPrefab, tempCursor);
                });
                break;
            case 6:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.threeRingPrefab, tempCursor);
                });
                break;
            case 3:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.fourRingPrefab, tempCursor);
                });
                break;
            case 2:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.sixRingPrefab, tempCursor);
                });
                break;
            case 1:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.sevenRingPrefab, tempCursor);
                });
                break;
            case 4:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.nineRingPrefab, tempCursor);
                });
                break;
            case 7:
                tempCursor = noteMap[currNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.tenRingPrefab, tempCursor);
                });
                break;
        }

        currNote++;
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
