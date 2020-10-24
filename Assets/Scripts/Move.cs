using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public float turnSpeed = 4.0f;
    public float minTurnAngle = -90.0f;
    public float maxTurnAngle = 90.0f;

    private float rotationX;


    // Update is called once per frame
    void Update()
    {
        KeyboardMoving();
        MouseAiming();
    }

    void KeyboardMoving()
    {
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed, vertical = Input.GetAxis("Vertical") * moveSpeed;
        Vector3 movement = (Vector3.right * horizontal + Vector3.forward * vertical) * Time.deltaTime;
        transform.Translate(movement);
    }

    void MouseAiming()
    {
        float y = Input.GetAxis("Mouse X") * turnSpeed;
        rotationX += Input.GetAxis("Mouse Y") * turnSpeed;
        rotationX = Mathf.Clamp(rotationX, minTurnAngle, maxTurnAngle);
        transform.eulerAngles = new Vector3(-rotationX, transform.eulerAngles.y + y, 0);
    }
}
