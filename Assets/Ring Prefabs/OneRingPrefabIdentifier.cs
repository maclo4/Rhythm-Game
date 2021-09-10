using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var OneRing = GameObject.Find("1 Ring");
        if (OneRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var OneRing = GameObject.Find("1 Ring");
        if (OneRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}

