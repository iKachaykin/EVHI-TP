using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEnemyParticles : MonoBehaviour
{
    private string particleTag = "EnemyParticle";
    private GameObject[] particles;
    private Dictionary<int, float> progress;
    private float destroyProgress = 0f, destroyReload = 0.2f;

    public float existance = 5f;
    // Start is called before the first frame update
    void Start()
    {
        progress = new Dictionary<int, float>();   
    }

    // Update is called once per frame
    void Update()
    {
        int idParticle;
        particles = GameObject.FindGameObjectsWithTag(particleTag);
        foreach (GameObject particle in particles)
        {
            destroyProgress += Time.deltaTime;
            idParticle = particle.GetInstanceID();
            if (progress.ContainsKey(idParticle))
                progress[idParticle] += Time.deltaTime;
            else
                progress.Add(idParticle, 0f);
            if (destroyProgress > destroyReload && progress[idParticle] > existance)
            {
                destroyProgress = 0f;
                Destroy(particle);
            }
        }
        
    }
}
