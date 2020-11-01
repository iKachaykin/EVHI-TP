using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayerOut : MonoBehaviour
{
    public float absForce = 2000f;
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
        Rigidbody colrb = collision.gameObject.GetComponent<Rigidbody>();
        if (colrb != null)
            colrb.AddForce(absForce * (new Vector3(-collision.gameObject.transform.forward.x, 0f, -collision.gameObject.transform.forward.z)));
    }
}
