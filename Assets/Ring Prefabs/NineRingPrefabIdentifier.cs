using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NineRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var nineRing = GameObject.Find("9 Ring");
        if (nineRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var nineRing = GameObject.Find("9 Ring");
        if (nineRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}
