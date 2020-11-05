using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    private GameObject cube;

    public float rotationSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        cube = transform.Find("Cube").gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.rotation = Quaternion.RotateTowards(cube.transform.rotation, Quaternion.Euler(0, cube.transform.rotation.eulerAngles.y + 1, 0), rotationSpeed * Time.deltaTime);
    }
}
