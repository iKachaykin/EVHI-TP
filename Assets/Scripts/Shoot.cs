using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject missilePrefab;
    public float reloadTime = 0.5f;
    public float reloadProgress = 0f;
    public float weaponForce = 5000f;
    public Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadProgress += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && reloadProgress >= reloadTime)
        {
            GameObject missileInstance;
            missileInstance = Instantiate<GameObject>(missilePrefab, playerCam.transform.position, playerCam.transform.rotation);
            Rigidbody missileRB = missileInstance.GetComponent<Rigidbody>();
            missileRB.AddForce(playerCam.transform.up * weaponForce);
            reloadProgress = 0;
        }
    }
}
