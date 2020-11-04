using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectUsedBossWeaponShells : MonoBehaviour
{
    private string shellTag = "BossWeaponShell";
    private GameObject[] shells;
    private Dictionary<int, float> progress;

    public float existance = 15f;
    // Start is called before the first frame update
    void Start()
    {
        progress = new Dictionary<int, float>();
    }

    // Update is called once per frame
    void Update()
    {
        int idShell;
        shells = GameObject.FindGameObjectsWithTag(shellTag);
        foreach (GameObject shell in shells)
        {
            // Init dicts
            idShell = shell.GetInstanceID();
            if (progress.ContainsKey(idShell))
                progress[idShell] += Time.deltaTime;
            else
                progress.Add(idShell, 0f);
            if (progress[idShell] > existance)
                Destroy(shell);
        }
        
    }
}
