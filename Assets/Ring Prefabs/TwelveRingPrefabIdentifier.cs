using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwelveRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var twelveRing = GameObject.Find("12 Ring");
        if (twelveRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var twelveRing = GameObject.Find("12 Ring");
        if (twelveRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}
