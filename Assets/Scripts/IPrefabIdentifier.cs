using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPrefabIdentifier
{
    public void EnterNoteAcceptedZone();
    public void ExitNoteAcceptedZone();
    void EnterLeftNoteAcceptedZone();
    void EnterRightNoteAcceptedZone();
}

