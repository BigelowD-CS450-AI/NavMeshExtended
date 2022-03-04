using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
