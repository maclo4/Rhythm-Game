using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHandler : MonoBehaviour
{
    //SpriteRenderer spriteRenderer;
    public void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
        gameObject.SetActive(false);
        
    }
}
