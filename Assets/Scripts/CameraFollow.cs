using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    public float lerpSpeed;

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpSpeed * Time.deltaTime);
    }

    private IEnumerator LateStart()
    {
        yield return null;
        target = CarController.Instance.transform;
        transform.position = target.position;
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
    }
}
