using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airport : MonoBehaviour
{
    public Sprite carSprite;
    public Sprite planeSprite;

    public List<BoxCollider2D> colliders;
    public BoxCollider2D airportTrigger;

    private void Start()
    {
        airportTrigger.enabled = false;

        foreach (BoxCollider2D collider in FindObjectsOfType<BoxCollider2D>())
        {
            if (collider.gameObject.CompareTag("Building"))
            {
                colliders.Add(collider);
            }
        }
    }

    public void ChangeSprite()
    {
        CarController.Instance.SetSprite(planeSprite);

        SetColliders(false);

        airportTrigger.enabled = true;
    }

    public void ArriveAtAirport()
    {
        Debug.Log("Arrived At Airport");
        CarController.Instance.SetSprite(carSprite);

        SetColliders(true);

        airportTrigger.enabled = false;
    }

    private void SetColliders(bool state)
    {
        foreach (BoxCollider2D collider in colliders)
        {
            collider.enabled = state;
        }
    }
}
