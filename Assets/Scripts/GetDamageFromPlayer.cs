using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDamageFromPlayer : MonoBehaviour
{
    public float resistance = 0f;
    public int particlesNumber = 100;
    public GameObject particlePrefab;

    private string missileTag = "Missile";
    private Health health;
    private Color particlesColor = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth != health.maxHealth && health.maxHealth != 0)
            GetComponent<Renderer>().material.color = new Color(1, (float)health.currentHealth / health.maxHealth, (float)health.currentHealth / health.maxHealth, GetComponent<Renderer>().material.color.a);
        if (health.currentHealth <= 0)
        {
            GenerateParticles();
            Destroy(gameObject);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(missileTag))
        {
            MissileConfig mc = collision.gameObject.GetComponent<MissileConfig>();
            health.GetDamage((int)Mathf.Round((1.0f - resistance) * mc.damage));        }

    }

    void GenerateParticles()
    {
        for (int i = 0; i < particlesNumber; i++)
        {
            GameObject particleInstance = Instantiate<GameObject>(particlePrefab, transform.position, transform.rotation);
            particleInstance.GetComponent<Renderer>().material.color = particlesColor;
        }

    }
}
