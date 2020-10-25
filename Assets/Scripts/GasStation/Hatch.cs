using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    public Color tint;
    public GameObject openHatch;
    public GameObject closeHatch;

    private bool hatchOpen;

    private void OnMouseOver()
    {
        SetSpriteColor(tint);
    }

    private void OnMouseExit()
    {
        SetSpriteColor(Color.white);
    }

    private void OnMouseDown()
    {
        ChangeHatch(hatchOpen);
        hatchOpen = !hatchOpen;
    }

    private void ChangeHatch(bool state)
    {
        openHatch.SetActive(state);
        closeHatch.SetActive(!state);
    }

    private void SetSpriteColor(Color color)
    {
        openHatch.GetComponent<SpriteRenderer>().color = color;
        closeHatch.GetComponent<SpriteRenderer>().color = color;
    }
}
