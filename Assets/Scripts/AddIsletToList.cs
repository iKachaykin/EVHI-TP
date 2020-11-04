using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIsletToList : MonoBehaviour
{
    private string playerTag = "Player";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
            GameObject.Find("Stage 4/LavaFloor").GetComponent<LavaBehaviour>().islets.Add(gameObject);
    }
}
