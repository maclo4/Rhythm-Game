using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeRingPrefabIdentifier : MonoBehaviour, IPrefabIdentifier
{
    public void EnterNoteAcceptedZone()
    {
        var threeRing = GameObject.Find("3 Ring");
        if (threeRing.TryGetComponent(out NoteController noteController))
        {
            noteController.EnterAcceptanceZone();
        }
    }
    public void ExitNoteAcceptedZone()
    {
        var threeRing = GameObject.Find("3 Ring");
        if (threeRing.TryGetComponent(out NoteController noteController))
        {
            noteController.ExitAcceptanceZone();
        }
    }
}
