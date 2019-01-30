using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
using System;
using SaveIsEasy;

public class PauseMenuHandler : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject loadButton;

    GameSettings gameSettings;
    SaveLoadHandler saveHandler;

	// Use this for initialization
	void Start ()
    {
        gameSettings = FindObjectOfType<GameSettings>();
        saveHandler = FindObjectOfType<SaveLoadHandler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Destroy(gameSettings.gameObject);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void DeathReturn()
    {
        SaveIsEasyAPI.GetSceneFile("FallGame").Delete();
        SceneManager.LoadScene(0);
    }
}
