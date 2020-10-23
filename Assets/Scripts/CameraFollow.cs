using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float lerpSpeed;


    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, lerpSpeed * Time.deltaTime);

        Camera.main.orthographicSize -= Input.mouseScrollDelta.y;
    }
}
