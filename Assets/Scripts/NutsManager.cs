using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutsManager : MonoBehaviour
{
    [HideInInspector] public List<Nut> nuts;

    public Vector2 start;
    public Vector2 target;

    private void Start()
    {
        nuts = new List<Nut>();
        foreach (Nut nut in GameObject.FindObjectsOfType<Nut>())
        {
            nuts.Add(nut);
        }
    }

    public void NutCheck()
    {
        if (nuts.Count == 0)
        {
            Debug.Log("Initiate next sequence");
            // Initiate next sequence
        }
    }

    public void CantClickNuts()
    {
        foreach (Nut nut in nuts)
        {
            nut.isRotating = true;
        }
    }

    public void CanClickNuts()
    {
        foreach (Nut nut in nuts)
        {
            nut.isRotating = false;
        }
    }
}
