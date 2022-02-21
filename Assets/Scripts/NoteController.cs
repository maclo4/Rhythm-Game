using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private SpriteRenderer spriteRenderer;
    private AudioSource clickAudioSource;
    private bool noteAccepted;
    private byte missedNoteCounter = 0;
    public Cursor cursor;
    private void Awake()
    {
        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
        clickAudioSource = gameObject.GetComponent<AudioSource>();
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
                    clickAudioSource.PlayOneShot(clickAudioSource.clip, .5f);
                    spriteRenderer.color = new Color32(0, 255, 35, 255);
                    Debug.Log("ayy note accepted");
                    break;
                case Cursor.Left when other.CompareTag("Left Cursor"):
                    clickAudioSource.PlayOneShot(clickAudioSource.clip, .5f);
                    spriteRenderer.color = new Color32(0, 255, 35, 255);
                    Debug.Log("ayy note accepted");
                    break;
                case Cursor.Neutral:
                    clickAudioSource.PlayOneShot(clickAudioSource.clip, .5f);
                    spriteRenderer.color = new Color32(0, 255, 35, 255);
                    Debug.Log("ayy note accepted");
                    break;
                default:
                    missedNoteCounter++;
                    //clickAudioSource.PlayOneShot(clickAudioSource.clip, .7f);
                    spriteRenderer.color = new Color32(255, 0, 0, 255);
                    Debug.Log("note denied :(");
                    break;
            }
        }
        else
        {
            missedNoteCounter++;
            //clickAudioSource.PlayOneShot(clickAudioSource.clip, .7f);
            spriteRenderer.color = new Color32(255, 0, 0, 255);
            Debug.Log("note denied :(");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        spriteRenderer.color = new Color32(0, 117, 255, 255);
    }
}
