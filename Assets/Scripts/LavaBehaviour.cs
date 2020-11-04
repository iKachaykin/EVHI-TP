using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LavaBehaviour : MonoBehaviour
{
    private string playerTag = "Player";
    private float blackScreenDuration = 1f, blackScreenProgress = 0f;
    private float collisionReloadDuration = 1f, collisionReloadProgress = 0f;
    private bool showBlackScreen = false;
    private Transform lastIsletTransform;
    private float verticalGap = 1f;
    private Move playerMove;

    public int lavaDamage = 100;
    public GameObject blackScreen;
    public GameObject defaultIslet;
    [HideInInspector]
    public List<GameObject> islets;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen.SetActive(false);
        islets = new List<GameObject>();
        islets.Add(defaultIslet);
    }

    // Update is called once per frame
    void Update()
    {
        if (showBlackScreen)
        {
            blackScreenProgress += Time.deltaTime;
            if (blackScreenProgress >= blackScreenDuration)
            {
                blackScreen.SetActive(false);
                showBlackScreen = false;
                playerMove.enabled = true;
                blackScreenProgress = 0f;
            }
        }
        collisionReloadProgress += Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collisionReloadProgress < collisionReloadDuration)
            return;
        // Debug.Log("Here");
        collisionReloadProgress = 0f;
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
            health.GetDamage(lavaDamage);
        if (collision.gameObject.CompareTag(playerTag))
        {
            blackScreen.SetActive(true);
            showBlackScreen = true;
            playerMove = collision.gameObject.GetComponent<Move>();
            playerMove.enabled = false;
            lastIsletTransform = islets[islets.Count - 1].transform;
            collision.gameObject.transform.position = new Vector3(lastIsletTransform.position.x, lastIsletTransform.position.y + lastIsletTransform.localScale.y / 2f + verticalGap, lastIsletTransform.position.z);
        }
    }
}
