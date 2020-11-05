using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFirstAidKits : MonoBehaviour
{
    private string floorTag = "Floor", isletTag = "Islet";
    private List<GameObject> placesToSpawn;
    private List<int> spawnIndices;
    private int fixedHeight = 1;

    public int number = 10;
    public GameObject firstAidKitPrefab;
    // Start is called before the first frame update
    void Start()
    {
        placesToSpawn = new List<GameObject>();
        placesToSpawn.AddRange(GameObject.FindGameObjectsWithTag(floorTag));
        placesToSpawn.AddRange(GameObject.FindGameObjectsWithTag(isletTag));
        
        spawnIndices = new List<int>();
        for (int i = 0; i < number; i++)
            spawnIndices.Add(Random.Range(0, placesToSpawn.Count));
        foreach (int index in spawnIndices)
        {
            Vector3 spawnPosition = new Vector3(
                Random.Range(placesToSpawn[index].transform.position.x - placesToSpawn[index].transform.localScale.x / 2f, placesToSpawn[index].transform.position.x + placesToSpawn[index].transform.localScale.x / 2f),
                fixedHeight,
                Random.Range(placesToSpawn[index].transform.position.z - placesToSpawn[index].transform.localScale.z / 2f, placesToSpawn[index].transform.position.z + placesToSpawn[index].transform.localScale.z / 2f));
            GameObject firstAidKitInstance = Instantiate<GameObject>(firstAidKitPrefab, spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
