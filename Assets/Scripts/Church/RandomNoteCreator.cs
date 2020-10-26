using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNoteCreator : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform spawnLocation;
    public List<Note> randomNotes;
    public List<Note> selectedNotes;
    public Animator selectableNotesAnimator;

    private void Start()
    {
        randomNotes = new List<Note>();
        selectedNotes = new List<Note>();

        StartCoroutine(SpawnNotes());
    }

    private IEnumerator SpawnNotes()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 4; i++)
        {
            GameObject newNote = Instantiate(notePrefab, spawnLocation.position, Quaternion.identity);
            newNote.GetComponentInChildren<Note>().fixedNote = false;
            randomNotes.Add(newNote.GetComponentInChildren<Note>());
            FindObjectOfType<Singer>().ChangeSingerSprite();
            yield return new WaitForSeconds(2f);
        }

        selectableNotesAnimator.SetTrigger("FlyIn");
    }

    public void AddSelectedNote(Note note)
    {
        StartCoroutine(AddSelectedNoteCoroutine(note));
    }

    private IEnumerator AddSelectedNoteCoroutine(Note note)
    {
        if (selectedNotes.Count != 4)
        {
            selectedNotes.Add(note);
        }

        FindObjectOfType<Singer>().ChangeSingerSprite();

        if (selectedNotes.Count == 4)
        {
            if (CheckSelectedNotes())
            {
                yield return new WaitForSeconds(3f);
                FindObjectOfType<MiniGameWon>().Win();
            }
            else
            {
                yield return new WaitForSeconds(3f);
                FindObjectOfType<MiniGameWon>().Loose();
            }
        }
    }

    public bool CheckSelectedNotes()
    {
        for (int i = 0; i < randomNotes.Count; i++)
        {
            if (randomNotes[i].noteType != selectedNotes[i].noteType)
            {
                return false;
            }
        }
        return true;
    }
}
