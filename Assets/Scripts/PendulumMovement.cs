using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{
    public string axis = "Z";
    public float minValue;
    public float maxValue;
    public float moveSpeed = 2.0f;

    private Vector3 direction;
    private Vector3 target;
    private bool minReached = false;
    private float eps = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        if (String.Compare(axis, "X") == 0 || String.Compare(axis, "x") == 0)
            direction = Vector3.right;
        if (String.Compare(axis, "Y") == 0 || String.Compare(axis, "y") == 0)
            direction = Vector3.up;
        if (String.Compare(axis, "Z") == 0 || String.Compare(axis, "z") == 0)
            direction = Vector3.forward;
        target = transform.position + minValue * direction - new Vector3(direction.x * transform.position.x, direction.y * transform.position.y, direction.z * transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < eps)
        {
            if (minReached)
            {
                minReached = false;
                target = transform.position + minValue * direction - new Vector3(direction.x * transform.position.x, direction.y * transform.position.y, direction.z * transform.position.z);
            }
            else
            {
                minReached = true;
                target = transform.position + maxValue * direction - new Vector3(direction.x * transform.position.x, direction.y * transform.position.y, direction.z * transform.position.z);
            }
        }
        
    }
}
