using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageCheckPoints : MonoBehaviour
{
    public List<CheckPoint> checkPoints;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        checkPoints = new List<CheckPoint>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class CheckPoint
{
    public Vector3 position;
    public Quaternion rotation;
    public float health;
    public CheckPoint(Vector3 position, Quaternion rotation, float health)
    {
        this.position = new Vector3(position.x, position.y, position.z);
        this.rotation = new Quaternion(rotation.x, rotation.y, rotation.z, rotation.w);
        this.health = health;
    }
}
