using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMask : MonoBehaviour
{
    public Vector3 offset;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset, 7f * Time.deltaTime);
    }
}
