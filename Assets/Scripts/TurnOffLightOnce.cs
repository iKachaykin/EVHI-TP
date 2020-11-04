using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLightOnce : MonoBehaviour
{
    public GameObject spotLight;
    private string lightTag = "Light", playerTag = "Player", lightBossTag = "LightBoss";
    private GameObject[] lights;
    private bool turnedOff = false;
    // Start is called before the first frame update
    void Start()
    {
        spotLight.SetActive(false);
        foreach (GameObject go in GameObject.FindGameObjectsWithTag(lightBossTag))
            go.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!turnedOff && collision.gameObject.CompareTag(playerTag))
        {
            lights = GameObject.FindGameObjectsWithTag(lightTag);
            foreach (GameObject light in lights)
                light.SetActive(false);
            spotLight.SetActive(true);
            turnedOff = true;
        }
    }
}
