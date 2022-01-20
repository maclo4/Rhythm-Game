using UnityEngine;

public enum Cursor { Left, Right, Neutral }

public class Note : MonoBehaviour
{
    public readonly int noteDirection;
    public readonly Cursor cursor;

    public Note(int noteDirection, Cursor cursor)
    {
        this.noteDirection = noteDirection;
        this.cursor = cursor;
    }
}
