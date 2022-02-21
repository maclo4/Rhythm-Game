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

    private float m_AnimationSpeed;
    private int m_CurrNote = 0;
    //private readonly List<int> m_NoteMap = new List<int>();
    private readonly List<Cursor> cursor = new List<Cursor>();
    private readonly List<Note> m_NoteMap = new List<Note>();
    public void Awake()
    {
        //rings.setAnimationSpeed(60f / bpm * 2);
        m_AnimationSpeed = 60f / bpm;
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
                    m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                    continue;
                }
                if (sr.Peek() < 0)
                {
                    m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                    continue;
                }

                var cursorDirection = Convert.ToChar(sr.Read());
                if (cursorDirection == ' ' && cursorDirection == '\n' && cursorDirection == '\r') continue;
                
                switch (cursorDirection)
                {
                    case 'L':
                    case 'l':
                        m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Left));
                        break;
                    case 'R':
                    case 'r':
                        m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Right));
                        break;
                    case 'N':
                    case 'n':
                        m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                        break;
                    default:
                        if (char.IsDigit(cursorDirection))
                        {
                            m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
                            m_NoteMap.Add(new Note((int)char.GetNumericValue(cursorDirection), Cursor.Neutral));
                        }
                        else
                        {
                            m_NoteMap.Add(new Note((int)char.GetNumericValue(noteDirection), Cursor.Neutral));
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
    private void PlayNote(GameObject note, Cursor cursor)
    {
        var prefab = Instantiate(note);
        
        if (!prefab.TryGetComponent(out Animator animator)) return;
        animator.speed = m_AnimationSpeed;
        
        var spriteRenderer = prefab.GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = new Color(255f, 131f, 131f, 255f);

        /*if (!prefab.TryGetComponent(out NoteController noteController)) return;
        noteController.cursor = cursor;*/
        
        if (cursor == Cursor.Left)
        {
            spriteRenderer.material.color = new Color(1f, 131f / 255, 131f / 255, 1f);
        }
        else if (cursor == Cursor.Right)
        {
            spriteRenderer.material.color = new Color(0f, 1f, 1f, 1f);
        }

        animator.SetTrigger("playNote");

    }
    public void NextNote()
    {
        if (m_CurrNote >= m_NoteMap.Count) return;

        Cursor tempCursor;
        switch (m_NoteMap[m_CurrNote].noteDirection)
        {
            case 8:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.twelveRingPrefab, tempCursor);
                });
                break;
            case 9:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.oneRingPrefab, tempCursor);
                });
                break;
            case 6:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.threeRingPrefab, tempCursor);
                });
                break;
            case 3:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.fourRingPrefab, tempCursor);
                });
                break;
            case 2:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.sixRingPrefab, tempCursor);
                });
                break;
            case 1:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.sevenRingPrefab, tempCursor);
                });
                break;
            case 4:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.nineRingPrefab, tempCursor);
                });
                break;
            case 7:
                tempCursor = m_NoteMap[m_CurrNote].cursor;
                UnityThread.executeInUpdate(() =>
                {
                    PlayNote(rings.tenRingPrefab, tempCursor);
                });
                break;
        }

        m_CurrNote++;
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
