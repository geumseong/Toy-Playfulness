using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyNote : MonoBehaviour
{
    public Note.NoteType noteType;

    public Color wholeColor;
    public Color halfColor;
    public Color quarterColor;
    public Color eigthColor;

    public Animator emptyNoteAnimator;

    public void InitializeEmptyNote()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        SetNoteColor();
        emptyNoteAnimator.SetTrigger("Wiggle");
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    private void SetNoteColor()
    {
        switch (noteType)
        {
            case Note.NoteType.Whole:
                GetComponentInChildren<SpriteRenderer>().color = wholeColor;
                break;
            case Note.NoteType.Half:
                GetComponentInChildren<SpriteRenderer>().color = halfColor;
                break;
            case Note.NoteType.Quarter:
                GetComponentInChildren<SpriteRenderer>().color = quarterColor;
                break;
            case Note.NoteType.Eigth:
                GetComponentInChildren<SpriteRenderer>().color = eigthColor;
                break;
            default:
                break;
        }
    }
}
