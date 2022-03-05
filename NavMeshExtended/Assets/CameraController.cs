using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    private const float panSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.GetAxisRaw("Mouse Y"));
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            this.transform.position += new Vector3(Input.GetAxisRaw("Mouse X")*panSpeed, 0.0f, Input.GetAxisRaw("Mouse Y")*panSpeed);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            transform.position = target.position + offset;
        }
    }
}
