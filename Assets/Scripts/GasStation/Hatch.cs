using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    public Color tint;
    public GameObject openHatch;
    public GameObject closeHatch;

    public bool hatchOpen;

    private void Start()
    {
        ChangeHatch(hatchOpen);
    }

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
    }

    private void ChangeHatch(bool state)
    {
        openHatch.SetActive(state);
        closeHatch.SetActive(!state);
        FindObjectOfType<GasStationManager>().HatchClosed = !hatchOpen;
        hatchOpen = !hatchOpen;
    }

    private void SetSpriteColor(Color color)
    {
        openHatch.GetComponent<SpriteRenderer>().color = color;
        closeHatch.GetComponent<SpriteRenderer>().color = color;
    }
}
