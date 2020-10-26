using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singer : MonoBehaviour
{
    public bool isMouthOpen;
    public Sprite[] singerSprites;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = singerSprites[1];
    }

    public void ChangeSingerSprite()
    {
        StartCoroutine(ChangeSpriteCoroutine());
    }

    private IEnumerator ChangeSpriteCoroutine()
    {
        SetSingerSprite(true);
        yield return new WaitForSeconds(0.5f);
        SetSingerSprite(false);
    }

    private void SetSingerSprite(bool mouthOpen)
    {
        if (mouthOpen)
            spriteRenderer.sprite = singerSprites[0];
        else
            spriteRenderer.sprite = singerSprites[1];

        isMouthOpen = mouthOpen;
    }
}
