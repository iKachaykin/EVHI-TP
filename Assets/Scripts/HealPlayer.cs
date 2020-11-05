using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    public int healAmount = 10;
    private string playerTag = "Player";
    private Health playerHealth = null;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth == null)
            playerHealth = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Health>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag) && playerHealth != null)
        {
            playerHealth.GetHealing(healAmount);
            Destroy(gameObject);
        }
    }
}
