using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject emptyNotePrefab;

    public bool fixedNote;

    public enum NoteType
    {
        Whole,
        Half,
        Quarter,
        Eigth,
        Fixed
    }

    public NoteType noteType;

    public Animator noteAnimator;

    public Color tint;

    public Color wholeColor;
    public Color halfColor;
    public Color quarterColor;
    public Color eigthColor;

    public Sprite[] noteSprites;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    public AudioClip[] clips;

    private void Start()
    {
        if (fixedNote)
        {
            SetNoteScale();
            gameObject.AddComponent<BoxCollider2D>();
        }
        else
        {
            InitializeNote();
            // change note sprite;
            transform.localScale = new Vector2(50, 50);
            noteAnimator.SetTrigger("Wiggle");
            spriteRenderer = GetComponent<SpriteRenderer>();
            SetNoteSprite();
            PlayNoteSound();
            StartCoroutine(HideDelay(2.5f));
        }
        SetNoteColor();
    }

    private void OnMouseDown()
    {
        if (fixedNote && FindObjectOfType<RandomNoteCreator>().selectedNotes.Count < 4)
        {
            FindObjectOfType<RandomNoteCreator>().AddSelectedNote(this);
            GameObject emptyNote = Instantiate(emptyNotePrefab, transform.position, Quaternion.identity);
            emptyNote.transform.GetChild(0).gameObject.GetComponent<EmptyNote>().noteType = noteType;
            emptyNote.transform.GetChild(0).gameObject.GetComponent<EmptyNote>().InitializeEmptyNote();
        }
    }

    private void OnMouseOver()
    {
        if (fixedNote)
        {
            GetComponent<SpriteRenderer>().color = tint;
        }
    }

    private void OnMouseExit()
    {
        if (fixedNote)
        {
            SetNoteColor();
        }
    }

    public void InitializeNote()
    {
        SetRandomNoteType();
    }

    private IEnumerator HideDelay(float delay)
    {
        FindObjectOfType<Singer>().ChangeSingerSprite();
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    private void PlayNoteSound()
    {
        audioSource = GetComponent<AudioSource>();
        switch (noteType)
        {
            case NoteType.Whole:
                audioSource.clip = clips[0];
                break;
            case NoteType.Half:
                audioSource.clip = clips[1];
                break;
            case NoteType.Quarter:
                audioSource.clip = clips[2];
                break;
            case NoteType.Eigth:
                audioSource.clip = clips[3];
                break;
            default:
                break;
        }

        audioSource.Play();
    }

    private void SetRandomNoteType()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                noteType = NoteType.Whole;

                break;
            case 1:
                noteType = NoteType.Half;

                break;
            case 2:
                noteType = NoteType.Quarter;

                break;
            case 3:
                noteType = NoteType.Eigth;
                break;
            default:
                break;
        }
    }

    private void SetNoteSprite()
    {
        switch (noteType)
        {
            case NoteType.Whole:
                spriteRenderer.sprite = noteSprites[0];
                break;
            case NoteType.Half:
                spriteRenderer.sprite = noteSprites[1];
                break;
            case NoteType.Quarter:
                spriteRenderer.sprite = noteSprites[2];
                break;
            case NoteType.Eigth:
                spriteRenderer.sprite = noteSprites[3];
                break;
            default:
                break;
        }
        transform.localScale = Vector2.one / 2f;
    }

    private void SetNoteScale()
    {
        switch (noteType)
        {
            case NoteType.Whole:
                transform.parent.localScale = new Vector2(8, 1);
                break;
            case NoteType.Half:
                transform.parent.localScale = new Vector2(6, 1);
                break;
            case NoteType.Quarter:
                transform.parent.localScale = new Vector2(4, 1);
                break;
            case NoteType.Eigth:
                transform.parent.localScale = new Vector2(2, 1);
                break;
            default:
                break;
        }
    }

    private void SetNoteColor()
    {
        switch (noteType)
        {
            case NoteType.Whole:
                GetComponentInChildren<SpriteRenderer>().color = wholeColor;
                break;
            case NoteType.Half:
                GetComponentInChildren<SpriteRenderer>().color = halfColor;
                break;
            case NoteType.Quarter:
                GetComponentInChildren<SpriteRenderer>().color = quarterColor;
                break;
            case NoteType.Eigth:
                GetComponentInChildren<SpriteRenderer>().color = eigthColor;
                break;
            default:
                break;
        }
    }
}
