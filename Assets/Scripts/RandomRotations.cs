using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotations : MonoBehaviour
{
    public float rotationSpeed;

    private Quaternion target;
    private float eps = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        target = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.rotation.eulerAngles, target.eulerAngles) > eps)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, rotationSpeed * Time.deltaTime);
        else
            target = Quaternion.Euler(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }
}
