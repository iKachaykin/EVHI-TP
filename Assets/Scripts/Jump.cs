using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public Rigidbody body;

    private float distanceToFloor;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        distanceToFloor = col.bounds.extents.y;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && OnGround())
            body.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
    }

    bool OnGround()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distanceToFloor + 0.1f);
    }
}
