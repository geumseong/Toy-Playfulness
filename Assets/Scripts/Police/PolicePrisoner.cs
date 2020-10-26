using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicePrisoner : MonoBehaviour
{
    public Sprite[] sprites;
    public SpriteRenderer[] exclamationMark;
    private bool prisonerFound;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        transform.position = new Vector2(Random.Range(-8f, 8f), Random.Range(3.4f, -3.4f));
        gameObject.AddComponent<BoxCollider2D>();
        exclamationMark[0].enabled = false;
        exclamationMark[1].enabled = false;
    }

    private void OnMouseDown()
    {
        if (!prisonerFound)
            StartCoroutine(PrisonerFoundDelay());
    }

    private IEnumerator PrisonerFoundDelay()
    {
        prisonerFound = true;
        FindObjectOfType<PoliceMask>().ScaleMaskUp();
        exclamationMark[0].enabled = true;
        exclamationMark[1].enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetTrigger("PrisonerFound");
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<MiniGameWon>().Win();
    }
}
