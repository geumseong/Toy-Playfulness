using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerpSpeed;

    private void Start()
    {
        target = CarController.Instance.transform;
        transform.position = target.position;
        Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpSpeed * Time.deltaTime);
    }
}
