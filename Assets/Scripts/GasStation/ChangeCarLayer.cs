using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCarLayer : MonoBehaviour
{
    public SpriteRenderer car;

    public void ChangeSpriteMaskLayer()
    {
        car.sortingOrder = 0;
    }
}
