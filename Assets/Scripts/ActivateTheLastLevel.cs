using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTheLastLevel : MonoBehaviour
{
    private string playerTag = "Player";
    private bool buttonIsDown = false, levelActivated = false, someonePressed = false;
    private float eps = 0.001f;
    private Vector3 targetButton;
    private Vector3 bossInitialPosition;
    private Vector3 bossInitialRotationEuler;
    
    public GameObject[] lightsToTurnOn;
    public float downSpeedButton = 0.1f;
    public float descentGap = 0.01f;
    public GameObject spotLight;
    public GameObject boss;
    public GameObject bossHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        targetButton = new Vector3(transform.position.x, -transform.localScale.y / 2 + descentGap, transform.position.z);
        bossInitialPosition = new Vector3(-27.44f, 10f, -0.51f);
        bossInitialRotationEuler = new Vector3(0f, 180f, 0f);
        boss.SetActive(false);
        bossHealthBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonIsDown && levelActivated)
            return;
        if (someonePressed && !buttonIsDown)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetButton, downSpeedButton * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetButton) <= eps)
                buttonIsDown = true;
        }
        if (buttonIsDown)
        {
            foreach(GameObject light in lightsToTurnOn)
                light.SetActive(true);
            spotLight.SetActive(false);
            boss.SetActive(true);
            bossHealthBar.SetActive(true);
            levelActivated = true;
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
        if (!collision.gameObject.CompareTag(playerTag))
            return;
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

    public bool LevelActivated()
    {
        return levelActivated;
    }
}
