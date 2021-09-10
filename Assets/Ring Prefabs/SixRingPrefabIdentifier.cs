using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var threeRing = GameObject.Find("6 Ring");
        if (threeRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var threeRing = GameObject.Find("6 Ring");
        if (threeRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}

