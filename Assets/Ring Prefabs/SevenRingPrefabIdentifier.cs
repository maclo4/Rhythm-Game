using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var ring = GameObject.Find("730 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var ring = GameObject.Find("730 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
    public void EnterRightNoteAcceptedZone()
    {
        var ring = GameObject.Find("730 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterRightAcceptanceZone();
        }
    }
    public void EnterLeftNoteAcceptedZone()
    {
        var ring = GameObject.Find("730 Ring");
        if (ring.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterLeftAcceptanceZone();
        }
    }
}
