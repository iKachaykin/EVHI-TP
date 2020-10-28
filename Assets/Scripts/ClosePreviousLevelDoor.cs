using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ClosePreviousLevelDoor : MonoBehaviour
{
    private bool playerPassed = false;
    private bool doorIsUp = false;
    private Vector3 targetDoor;
    private float eps = 0.001f;
    private long timeToWait = 150;
    private Stopwatch stopWatch;
    private bool destroyedUnused = false;

    public GameObject door;
    public float upSpeedDoor = 10.0f;
    public float descentGap = 0.01f;
    public Color closedDoorColor = Color.red;
    public GameObject[] unusedGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        targetDoor = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z);
        stopWatch = new Stopwatch();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorIsUp)
            return;
        if (playerPassed)
        {
            if (stopWatch.ElapsedMilliseconds < timeToWait)
                return;
            else if (stopWatch.IsRunning)
                stopWatch.Stop();
            if (!destroyedUnused)
            {
                DestroyUnused();
                destroyedUnused = true;
            }
            door.transform.position = Vector3.MoveTowards(door.transform.position, targetDoor, upSpeedDoor * Time.deltaTime);
            if (Vector3.Distance(door.transform.position, targetDoor) <= eps)
                doorIsUp = true;
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
        if (!playerPassed)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                if (contact.point.x > transform.position.x - transform.localScale.x / 2 && 
                    contact.point.x < transform.position.x + transform.localScale.x / 2 &&
                    contact.point.z > transform.position.z - transform.localScale.z / 2 &&
                    contact.point.z < transform.position.z + transform.localScale.z / 2)
                {
                    door.GetComponent<Renderer>().material.color = closedDoorColor;
                    playerPassed = true;
                    stopWatch.Start();
                    return;
                }
            }
        }
    }

    void DestroyUnused()
    {
        // GameObject[] unusedGameObjects = GameObject.FindGameObjectsWithTag("ToDestroy");
        foreach (GameObject go in unusedGameObjects)
            Destroy(go);
    }

}
