using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicePrisoner : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector2(Random.Range(-6.38f, 4.13f), Random.Range(6.38f, -4.13f));
    }

    private void OnMouseDown()
    {
        SceneLoader.Instance.LoadScene(2);
    }
}
