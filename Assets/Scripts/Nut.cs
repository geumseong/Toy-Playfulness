using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut : MonoBehaviour
{
    public Color tint;
    [HideInInspector] public bool isNewTire;

    private NutsManager nutsManager;
    private SpriteRenderer spriteRenderer;
    public Color standardColor;
    [HideInInspector] public bool isRotating;

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
            StartCoroutine(Rotate());
    }

    private void OnMouseOver()
    {
        if (!isRotating)
            SetSpriteColor(tint);
    }

    private void OnMouseExit()
    {
        SetSpriteColor(standardColor);
    }

    public void SetSpriteColor(Color color)
    {
        spriteRenderer.color = color;
    }

    private IEnumerator Rotate()
    {
        isRotating = true;
        SetSpriteColor(standardColor);
        for (int i = 0; i < 144; i++)
        {
            if (isNewTire)
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 5);
            else
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 5);
            yield return null;
        }

        if (isNewTire)
        {
            nutsManager.nuts.Add(this);
            nutsManager.NutCheck();
        }
        else
        {
            nutsManager.nuts.Remove(this);
            nutsManager.NutCheck();
            Destroy(gameObject);
        }
    }
}
