using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var TenRing = GameObject.Find("10 Ring");
        if (TenRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var TenRing = GameObject.Find("10 Ring");
        if (TenRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}
