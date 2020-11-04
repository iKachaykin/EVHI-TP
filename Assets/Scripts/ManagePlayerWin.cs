using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagePlayerWin : MonoBehaviour
{
    public GameObject winPanel;
    public Camera mainCamera, playerWinCamera;
    public Button RestartButton, ExitButton;

    private string playerWinTag = "PlayerWin";
    private string bossTag = "Boss";
    private Health bossHealth;
    private float progress = 0f, lim = 5f;
    private bool bossHealthAssigned = false;
    // Start is called before the first frame update
    void Start()
    {
        winPanel.SetActive(false);

        Button ebtn = ExitButton.GetComponent<Button>();
        ebtn.onClick.AddListener(ExitGame);

        Button rbtn = RestartButton.GetComponent<Button>();
        rbtn.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag(bossTag) == null)
            return;
        else if (!bossHealthAssigned)
        {
            bossHealth = GameObject.FindGameObjectWithTag(bossTag).GetComponent<Health>();
            bossHealthAssigned = true;
        }
        if(bossHealth.currentHealth <= 0)
        {
            progress += Time.deltaTime;
            if (progress < lim)
                return;
            GameObject canvas = GameObject.Find("Canvas");
            foreach (Transform child in canvas.transform)
                if (!child.gameObject.CompareTag(playerWinTag))
                    child.gameObject.SetActive(false);
            GameObject.Find("PauseMenuManager").GetComponent<ManagePauseMenu>().enabled = false;
            mainCamera.enabled = false;
            
            playerWinCamera.enabled = true;
            winPanel.SetActive(true);
            Cursor.visible = true;
        }
        
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
