using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private SpriteRenderer spriteRenderer;
    private AudioSource clickAudioSource;
    bool noteAccepted = false;
    //public AudioClip click;
    private void Awake()
    {
        edgeCollider = gameObject.GetComponent<EdgeCollider2D>();
        spriteRenderer = gameObject.GetComponentInParent<SpriteRenderer>();
        clickAudioSource = gameObject.GetComponent<AudioSource>();
    }
    public void StartCheckingCollision()
    {
        //Application.targetFrameRate = 300;
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

    public void OnTriggerEnter2D()
    {
        //clickAudioSource.Play();

        
        Debug.Log("ayy collision works");
        

        if(noteAccepted == true)
        {
            clickAudioSource.PlayOneShot(clickAudioSource.clip, 1);
            spriteRenderer.color = new Color32(0, 255, 35, 255);
            Debug.Log("ayy note accepted");
        }
        else
        {

            clickAudioSource.PlayOneShot(clickAudioSource.clip, .7f);
            spriteRenderer.color = new Color32(255, 0, 0, 255);
            Debug.Log("note denied :(");
        }
    }

    //public void OnTriggerStay2D(Collider2D collision)
    //{
    //    spriteRenderer.color = new Color32(255, 0, 0, 255);
    //}

    public void OnTriggerExit2D()
    {
        spriteRenderer.color = new Color32(255, 131, 131, 255);
    }
}
