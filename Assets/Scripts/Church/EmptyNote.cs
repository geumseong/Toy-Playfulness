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

    public Sprite[] noteSprites;
    private SpriteRenderer spriteRenderer;

    public AudioClip[] clips;
    private AudioSource audioSource;

    public void InitializeEmptyNote()
    {
        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetNoteColor();
        SetNoteSprite();
        PlayNoteSound();
        emptyNoteAnimator.SetTrigger("Wiggle");
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    private void PlayNoteSound()
    {
        audioSource = GetComponent<AudioSource>();
        switch (noteType)
        {
            case Note.NoteType.Whole:
                audioSource.clip = clips[0];
                break;
            case Note.NoteType.Half:
                audioSource.clip = clips[1];
                break;
            case Note.NoteType.Quarter:
                audioSource.clip = clips[2];
                break;
            case Note.NoteType.Eigth:
                audioSource.clip = clips[3];
                break;
            default:
                break;
        }

        audioSource.Play();
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

    private void SetNoteSprite()
    {
        switch (noteType)
        {
            case Note.NoteType.Whole:
                spriteRenderer.sprite = noteSprites[0];
                break;
            case Note.NoteType.Half:
                spriteRenderer.sprite = noteSprites[1];
                break;
            case Note.NoteType.Quarter:
                spriteRenderer.sprite = noteSprites[2];
                break;
            case Note.NoteType.Eigth:
                spriteRenderer.sprite = noteSprites[3];
                break;
            default:
                break;
        }
        transform.localScale = Vector2.one / 2f;
    }
}
