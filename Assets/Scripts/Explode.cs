using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float existance = 5f;
    public GameObject particlePrefab;
    public int particlesNumber = 50;
    public float force = 5000f;

    private float progress = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > existance)
        {
            GenerateParticles();
            Destroy(gameObject);
        }
    }

    void GenerateParticles()
    {
        for (int i = 0; i < particlesNumber; i++)
        {
            GameObject particleInstance = Instantiate<GameObject>(particlePrefab, transform.position, transform.rotation);
            Rigidbody rb = particleInstance.GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(Random.Range(0, 1), 0, Random.Range(0, 1)) * force);
        }

    }
}
