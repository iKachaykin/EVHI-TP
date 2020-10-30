using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject missilePrefab;
    public float reloadTime = 0.5f;
    public float reloadProgress = 0f;
    public float weaponForce = 2000f;
    public float damage = 25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        reloadProgress += Time.deltaTime;
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && reloadProgress >= reloadTime)
        {
            GameObject weapon = transform.Find("Weapon").gameObject;

            GameObject missileInstance;
            missileInstance = Instantiate<GameObject>(missilePrefab, weapon.transform.position, weapon.transform.rotation);
            Rigidbody missileRB = missileInstance.GetComponent<Rigidbody>();
            missileRB.AddForce(weapon.transform.up * weaponForce);
            MissileConfig mc = missileInstance.GetComponent<MissileConfig>();
            mc.damage = damage;
            reloadProgress = 0;
        }
    }
}
