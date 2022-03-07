using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMover : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    private Vector3 startingPos;
    [SerializeField] private Vector4 boundingBox = new Vector4(-55.0f, 25.0f, 160.0f, 150.0f);

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
        if (transform.position.x < boundingBox.x || transform.position.x > boundingBox.z
            || transform.position.z < boundingBox.y || transform.position.z > boundingBox.w)
        {
            transform.position = startingPos;
        }
    }
}
