using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagePauseMenu : MonoBehaviour
{
    private GameObject[] pauseObjects;
    private GameObject[] onGameObjects;
    private bool onPause;

    public GameObject player;
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
            g.SetActive(false);
        foreach(GameObject g in onGameObjects)
            g.SetActive(true);
        Cursor.visible = false;
        onPause = false;
    }

    void PauseOn()
    {
        pauseCamera.enabled = true;
        player.SetActive(false);
        foreach(GameObject g in onGameObjects)
            g.SetActive(false);
        foreach(GameObject g in pauseObjects)
            g.SetActive(true);
        Cursor.visible = true;
        onPause = true;
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
