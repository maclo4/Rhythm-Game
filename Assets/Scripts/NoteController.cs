using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class NoteController : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private SpriteRenderer spriteRenderer;
    [FormerlySerializedAs("clickAudioSource")] 
    public AudioSource errorBuzz;
    public AudioSource noteHitClick;
    private bool noteAccepted;
    private byte missedNoteCounter = 0;
    public Cursor cursor;
    private void Awake()
    {
        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
       // clickAudioSource = gameObject.GetComponent<AudioSource>();
    }
    public void StartCheckingCollision()
    {
        edgeCollider.enabled = true;
    }

    public void EnterAcceptanceZone()
    {
        noteAccepted = true;
    }
    public void ExitAcceptanceZone()
    {
        noteAccepted = false;
        cursor = Cursor.Neutral;
    }

    public void EnterLeftAcceptanceZone()
    {
        noteAccepted = true;
        cursor = Cursor.Left;
    }

    public void EnterRightAcceptanceZone()
    {
        noteAccepted = true;
        cursor = Cursor.Right;
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        //clickAudioSource.Play();

        
        Debug.Log("ayy collision works");
        

        if(noteAccepted)
        {
            switch (cursor)
            {
                case Cursor.Right when other.CompareTag("Right Cursor"):
                    
                    spriteRenderer.color = new Color32(0, 255, 35, 255);
                    noteHitClick.PlayOneShot(noteHitClick.clip, .3f);
                    Debug.Log("ayy note accepted");
                    break;
                case Cursor.Left when other.CompareTag("Left Cursor"):
                    spriteRenderer.color = new Color32(0, 255, 35, 255);
                    noteHitClick.PlayOneShot(noteHitClick.clip, .3f);
                    Debug.Log("ayy note accepted");
                    break;
                case Cursor.Neutral:
                    spriteRenderer.color = new Color32(0, 255, 35, 255);
                    noteHitClick.PlayOneShot(noteHitClick.clip, .3f);
                    Debug.Log("ayy note accepted");
                    break;
                default:
                    missedNoteCounter++;
                    errorBuzz.PlayOneShot(errorBuzz.clip, .5f);
                    spriteRenderer.color = new Color32(255, 0, 0, 255);
                    Debug.Log("note denied :(");
                    break;
            }
        }
        else
        {
            missedNoteCounter++;
            errorBuzz.PlayOneShot(errorBuzz.clip, .5f);
            spriteRenderer.color = new Color32(255, 0, 0, 255);
            Debug.Log("note denied :(");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = new Color32(0, 117, 255, 255);
    }
}
