using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNextLevelFloor : MonoBehaviour
{
    private bool someoneStepped = false;
    private bool doorIsDown = false;
    private Vector3 targetDoor;
    private float eps = 0.001f;

    public GameObject door;
    public float downSpeedDoor = 1.0f;
    public float descentGap = 0.01f;
    public Color openDoorColor = Color.green;

    void Start()
    {
        targetDoor = new Vector3(door.transform.position.x, door.transform.position.y - door.transform.localScale.y + descentGap, door.transform.position.z);
    }

    void Update()
    {
        if (doorIsDown)
            return;
        if (someoneStepped)
        {
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetDoor, downSpeedDoor * Time.deltaTime);
            if (Vector3.Distance(door.transform.position, targetDoor) <= eps)
                doorIsDown = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }

    void OnCollisionStay(Collision collision)
    {
        OnCollision(collision);
    }

    void OnCollision(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;
        if (!someoneStepped)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.point.x > transform.position.x - transform.localScale.x / 2 && 
                    contact.point.x < transform.position.x + transform.localScale.x / 2 &&
                    contact.point.z > transform.position.z - transform.localScale.z / 2 &&
                    contact.point.z < transform.position.z + transform.localScale.z / 2)
                {
                    door.GetComponent<Renderer>().material.color = openDoorColor;
                    someoneStepped = true;
                    return;
                }
            }
        }
    }
}
