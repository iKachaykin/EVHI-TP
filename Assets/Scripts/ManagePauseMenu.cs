using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagePauseMenu : MonoBehaviour
{
    private GameObject[] pauseObjects;
    private GameObject[] onGameObjects;
    private bool onPause;

    public GameObject player;
    public GameObject boss;
    public GameObject bossHealthBar;
    public GameObject lastLevelButton;
    public Camera pauseCamera;
    public Button ContinueButton, RestartButton, ExitButton;
    // Start is called before the first frame update
    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("OnPause");
        onGameObjects = GameObject.FindGameObjectsWithTag("OnGame");
        PauseOff();
        onPause = false;
        pauseCamera.enabled = false;

        Button cbtn = ContinueButton.GetComponent<Button>();
        cbtn.onClick.AddListener(PauseOff);

        Button ebtn = ExitButton.GetComponent<Button>();
        ebtn.onClick.AddListener(ExitGame);

        Button rbtn = RestartButton.GetComponent<Button>();
        rbtn.onClick.AddListener(RestartGame);

        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPause)
                PauseOff();
            else
                PauseOn();
        }
        
    }

    void PauseOff()
    {
        player.SetActive(true);
        pauseCamera.enabled = false;
        foreach(GameObject g in pauseObjects)
            if (g != null)
                g.SetActive(false);
        foreach(GameObject g in onGameObjects)
            if (g != null)
                g.SetActive(true);
        if (lastLevelButton.GetComponent<ActivateTheLastLevel>().LevelActivated())
        {
            boss.SetActive(true);
            bossHealthBar.SetActive(true);
        }
        Cursor.visible = false;
        onPause = false;
    }

    void PauseOn()
    {
        pauseCamera.enabled = true;
        player.SetActive(false);
        foreach(GameObject g in onGameObjects)
            if (g != null)
                g.SetActive(false);
        foreach(GameObject g in pauseObjects)
            if (g != null)
                g.SetActive(true);
        if (lastLevelButton.GetComponent<ActivateTheLastLevel>().LevelActivated())
        {
            boss.SetActive(false);
            bossHealthBar.SetActive(false);
        }
        Cursor.visible = true;
        onPause = true;
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
