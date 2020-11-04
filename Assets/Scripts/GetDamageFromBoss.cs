using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamageFromBoss : MonoBehaviour
{
    public float resistance = 0f;

    private string shellTag = "BossWeaponShell";
    private Health health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(shellTag))
        {
            BossWeaponShellConfig sc = collision.gameObject.GetComponent<BossWeaponShellConfig>();
            health.GetDamage((int)Mathf.Round((1.0f - resistance) * sc.damage));
        }
    }
}
