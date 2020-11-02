using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float speed = 2.5f;
    public float vision = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < vision)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            transform.LookAt(player.transform);
        }
        // if (Vector3.Distance(transform.position, player.transform.position) < 0.001)
        //     transform.rotation = player.transform.rotation;
    }
}
