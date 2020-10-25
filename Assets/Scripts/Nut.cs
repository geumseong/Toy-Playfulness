using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public Color tint;

    private NutsManager nutsManager;
    private SpriteRenderer spriteRenderer;
    private Color standardColor;
    private bool isRotating;

    private void Start()
    {
        nutsManager = FindObjectOfType<NutsManager>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        standardColor = spriteRenderer.color;
        isRotating = false;
    }

    private void OnMouseDown()
    {
        if (!isRotating)
            StartCoroutine(RotateOut());
    }

    private void OnMouseOver()
    {
        if (!isRotating)
            spriteRenderer.color = tint;
    }

    private void OnMouseExit()
    {
        if (!isRotating)
            spriteRenderer.color = standardColor;
    }

    private IEnumerator RotateOut()
    {
        isRotating = true;
        for (int i = 0; i < 144; i++)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 5);
            yield return null;
        }


        nutsManager.nuts.Remove(this);
        nutsManager.NutCheck();
        Destroy(gameObject);
    }
}
