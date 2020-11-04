using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagePlayerDeath : MonoBehaviour
{
    public GameObject onDeathPanel;
    public Camera mainCamera, playerDeadCamera;
    public Button RestartButton, ExitButton;

    private string playerDeadTag = "PlayerDead";
    private string playerTag = "Player";
    private Health playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        onDeathPanel.SetActive(false);

        Button ebtn = ExitButton.GetComponent<Button>();
        ebtn.onClick.AddListener(ExitGame);

        Button rbtn = RestartButton.GetComponent<Button>();
        rbtn.onClick.AddListener(RestartGame);

        playerHealth = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth.currentHealth <= 0)
        {
            GameObject canvas = GameObject.Find("Canvas");
            foreach (Transform child in canvas.transform)
                if (!child.gameObject.CompareTag(playerDeadTag))
                    child.gameObject.SetActive(false);
            GameObject.Find("PauseMenuManager").GetComponent<ManagePauseMenu>().enabled = false;
            mainCamera.enabled = false;
            
            playerDeadCamera.enabled = true;
            onDeathPanel.SetActive(true);
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
