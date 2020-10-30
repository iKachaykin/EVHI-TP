using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepButtonInactive : MonoBehaviour
{
    public GameObject nextLevelButton;
    public GameObject nextLevelButtonFake;
    public float upSpeedButton = 0.1f;
    public GameObject enemy;
    
    private Health health;
    private Vector3 initButtonPosition;
    private float eps = 0.01f;
    private bool buttonActivated = false;
    private bool buttonReleased = false;
    // Start is called before the first frame update
    void Start()
    {
        health = enemy.GetComponent<Health>();
        initButtonPosition = nextLevelButton.transform.position;
        nextLevelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonReleased)
            return;
        if (health.currentHealth <= 0)
            ReleaseButton();
    }

    void ReleaseButton()
    {
        if (!buttonActivated)
        {
            buttonActivated = true;
            nextLevelButton.transform.position = new Vector3(
                nextLevelButton.transform.position.x, -nextLevelButton.transform.localScale.y + eps, nextLevelButton.transform.position.z);
            nextLevelButton.SetActive(true);
        }
        if (Vector3.Distance(nextLevelButton.transform.position, initButtonPosition) > eps)
            nextLevelButton.transform.position = Vector3.MoveTowards(nextLevelButton.transform.position, initButtonPosition, upSpeedButton * Time.deltaTime);
        else
        {
            buttonReleased = true;
            Destroy(nextLevelButtonFake);
        }

    }
}
