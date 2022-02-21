using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var ring = GameObject.Find("130 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var ring = GameObject.Find("130 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
    
    public void EnterLeftNoteAcceptedZone()
    {
        var ring = GameObject.Find("130 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterLeftAcceptanceZone();
        }
    }
    public void EnterRightNoteAcceptedZone()
    {
        var ring = GameObject.Find("130 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterRightAcceptanceZone();
        }
    }
}

