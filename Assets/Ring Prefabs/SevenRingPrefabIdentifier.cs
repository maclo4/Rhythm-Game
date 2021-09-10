using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SevenRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var SevenRing = GameObject.Find("730 Ring");
        if (SevenRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var SevenRing = GameObject.Find("730 Ring");
        if (SevenRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}
