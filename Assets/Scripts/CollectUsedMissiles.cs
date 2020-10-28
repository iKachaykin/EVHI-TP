using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CollectUsedMissiles : MonoBehaviour
{
    private string missileTag = "Missile";
    private GameObject[] missiles;
    private Dictionary<int, float> progressGeneral, progressUnderFloor;

    public float generalExistance = 15f, underFloorExistance = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        progressGeneral = new Dictionary<int, float>();
        progressUnderFloor = new Dictionary<int, float>();
    }

    // Update is called once per frame
    void Update()
    {
        int idMissile;
        missiles = GameObject.FindGameObjectsWithTag(missileTag);
        foreach (GameObject missile in missiles)
        {
            // Init dicts
            idMissile = missile.GetInstanceID();
            if (progressGeneral.ContainsKey(idMissile))
                progressGeneral[idMissile] += Time.deltaTime;
            else
                progressGeneral.Add(idMissile, 0f);
            if (progressUnderFloor.ContainsKey(idMissile))
                progressUnderFloor[idMissile] += Time.deltaTime;
            else
                progressUnderFloor.Add(idMissile, 0f);

            // If not under level reset progress
            if (missile.transform.position.y > 0)
                progressUnderFloor[idMissile] = 0f;

            if (progressUnderFloor[idMissile] > underFloorExistance || progressGeneral[idMissile] > generalExistance)
                Destroy(missile);
        }
        
    }
}
