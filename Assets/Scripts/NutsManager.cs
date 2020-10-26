using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutsManager : MonoBehaviour
{
    public GameObject tirePrefab;
    public GameObject nutPrefab;
    public Transform[] spawnPositions;
    public bool isNewTire;
    public List<Nut> nuts;

    public SpriteRenderer tireSpriteRenderer;
    public Sprite[] tires;

    private GameObject car;

    private void Start()
    {
        car = GameObject.Find("Car");
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            Instantiate(nutPrefab, spawnPositions[i].position, Quaternion.identity, spawnPositions[i]);
        }

        nuts = new List<Nut>();

        if (!isNewTire)
        {
            tireSpriteRenderer.sprite = tires[0];
            foreach (Nut nut in GameObject.FindObjectsOfType<Nut>())
            {
                nuts.Add(nut);
            }
        }
        else
        {
            tireSpriteRenderer.sprite = tires[1];
            foreach (Nut nut in GameObject.FindObjectsOfType<Nut>())
            {
                nut.isNewTire = this.isNewTire;
            }
        }
    }

    public void NutCheck()
    {
        if (isNewTire)
        {
            if (nuts.Count == 6)
            {
                car.GetComponent<Animator>().SetTrigger("CarDriveOff");
                gameObject.GetComponent<Animator>().SetTrigger("CarDriveOff");
            }
        }
        else
        {
            if (nuts.Count == 0)
            {
                GameObject newTire = Instantiate(tirePrefab, Vector3.zero, Quaternion.identity);
                newTire.GetComponent<NutsManager>().isNewTire = true;
                Destroy(gameObject);
            }
        }
    }

    public void CantClickNuts()
    {
        foreach (Nut nut in nuts)
        {
            nut.isRotating = true;
            nut.SetSpriteColor(nut.standardColor);
        }
    }

    public void CanClickNuts()
    {
        foreach (Nut nut in nuts)
        {
            nut.isRotating = false;
        }
    }

    public void WinScene()
    {
        SceneLoader.Instance.LoadScene(2);
    }
}
