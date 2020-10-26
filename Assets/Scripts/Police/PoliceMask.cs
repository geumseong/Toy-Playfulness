using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMask : MonoBehaviour
{
    public Vector3 offset;
    public float scaleSpeed;

    private void Start()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset, 7f * Time.deltaTime);
    }

    public void ScaleMaskUp()
    {
        StartCoroutine(WinDelay());
    }

    private IEnumerator WinDelay()
    {
        for (int i = 0; i < 200; i++)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(30, 30), scaleSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
