using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNextLevelButton : MonoBehaviour
{
    private bool someonePressed = false;
    private Vector3 targetButton, targetDoor;
    private float eps = 0.001f;

    public GameObject door;
    public float downSpeedButton = 0.1f;
    public float downSpeedDoor = 1.0f;
    public float descentGap = 0.01f;
    public Color openDoorColor = Color.green;

    void Start()
    {
        targetButton = new Vector3(transform.position.x, transform.position.y - transform.localScale.y + descentGap, transform.position.z);
        targetDoor = new Vector3(door.transform.position.x, door.transform.position.y - door.transform.localScale.y + descentGap, door.transform.position.z);
    }

    void Update()
    {
        if (someonePressed && Vector3.Distance(transform.position, targetButton) > eps)
            transform.position = Vector3.MoveTowards(transform.position, targetButton, downSpeedButton * Time.deltaTime);
        if (someonePressed && Vector3.Distance(door.transform.position, targetDoor) > eps)
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetDoor, downSpeedDoor * Time.deltaTime);
        if (someonePressed)
            door.GetComponent<Renderer>().material.color = openDoorColor;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (!someonePressed)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.point.x > transform.position.x - transform.localScale.x / 2 && 
                    contact.point.x < transform.position.x + transform.localScale.x / 2 &&
                    contact.point.z > transform.position.z - transform.localScale.z / 2 &&
                    contact.point.z < transform.position.z + transform.localScale.z / 2)
                {
                    someonePressed = true;
                    return;
                }
            }
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (!someonePressed)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.point.x > transform.position.x - transform.localScale.x / 2 && 
                    contact.point.x < transform.position.x + transform.localScale.x / 2 &&
                    contact.point.z > transform.position.z - transform.localScale.z / 2 &&
                    contact.point.z < transform.position.z + transform.localScale.z / 2)
                {
                    someonePressed = true;
                    return;
                }
            }
        }
    }
}
