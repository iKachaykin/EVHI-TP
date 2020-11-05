using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    private int shootingModesNum = 2;
    private int currentMode = 0;
    private float[] timePerMode = {5f, 5f};
    private float progressPerMode = 0f;
    private float reloadBetweenModes = 5f, progressBetweenModes = 0f;
    private float[] reload = {0.2f, 1.0f};
    private float progress = 0.0f;
    private float[] forces = {2500f, 500f};
    private float[] damages = {5f, 20f};
    private bool onReload = false;

    public GameObject[] shellPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onReload)
        {
            progressBetweenModes += Time.deltaTime;
            if (progressBetweenModes >= reloadBetweenModes)
            {
                onReload = false;
                progressPerMode = 0f;
            }

        }
        else 
        {
            progressPerMode += Time.deltaTime;
            if (currentMode == 0)
                ShootMode0();
            if (currentMode == 1)
                ShootMode1();
            if (progressPerMode >= timePerMode[currentMode])
            {
                currentMode = GetNextMode();
                progressBetweenModes = 0f;
                onReload = true;
                progress = reload[currentMode];
            }
        }
    }

    void ShootMode0()
    {
        progress += Time.deltaTime;
        if (progress >= reload[0])
        {
            GameObject weapon = transform.Find("Weapon").gameObject;
            GameObject shellInstance = Instantiate<GameObject>(shellPrefabs[0], weapon.transform.position, weapon.transform.rotation);
            Rigidbody shellRB = shellInstance.GetComponent<Rigidbody>();
            shellRB.AddForce(transform.forward * forces[0]);
            BossWeaponShellConfig sc = shellInstance.GetComponent<BossWeaponShellConfig>();
            sc.damage = damages[0];
            progress = 0f;
        }

    }

    void ShootMode1()
    {
        progress += Time.deltaTime;
        if (progress >= reload[1])
        {
            GameObject weapon = transform.Find("Weapon").gameObject;
            GameObject shellInstance = Instantiate<GameObject>(shellPrefabs[1], weapon.transform.position, weapon.transform.rotation);
            Rigidbody shellRB = shellInstance.GetComponent<Rigidbody>();
            shellRB.AddForce(transform.forward * forces[1]);
            BossWeaponShellConfig sc = shellInstance.GetComponent<BossWeaponShellConfig>();
            sc.damage = damages[1];
            progress = 0f;
        }

    }

    int GetNextMode()
    {
        if (currentMode == shootingModesNum - 1)
            return 0;
        return currentMode + 1;
    }
}
