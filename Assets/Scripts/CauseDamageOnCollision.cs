using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauseDamageOnCollision : MonoBehaviour
{
    public int damage = 10;

    private float reloadProgress = 0f, reloadLimit = 2f;
    private Health receiverHealth;
    private float eps = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        reloadProgress = reloadLimit + eps;
    }

    // Update is called once per frame
    void Update()
    {
        reloadProgress += Time.deltaTime;
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
        if (reloadProgress > reloadLimit)
        {
            reloadProgress = 0f;
            receiverHealth = collision.gameObject.GetComponent<Health>();
            if (receiverHealth != null)
                receiverHealth.GetDamage(damage);
        }
    }
}
