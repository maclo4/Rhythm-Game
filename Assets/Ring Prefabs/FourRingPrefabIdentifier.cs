using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    
    public void EnterNoteAcceptedZone()
    {
        var FourRing = GameObject.Find("430 Ring");
        if (FourRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var FourRing = GameObject.Find("430 Ring");
        if (FourRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}
