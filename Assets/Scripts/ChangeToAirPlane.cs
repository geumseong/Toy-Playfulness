using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToAirPlane : MonoBehaviour
{
    public Sprite planeSprite;

    public void ChangeSprite()
    {
        CarController.Instance.SetSprite(planeSprite);
    }
}
