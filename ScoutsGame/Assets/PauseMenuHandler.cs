using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;
using System;

public class PauseMenuHandler : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject loadButton;

    SaveLoadHandler saveHandler;

	// Use this for initialization
	void Start ()
    {
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

        CheckForSaveFile();
	}

    private void CheckForSaveFile()
    {
        if (SaveGame.Exists("PlayerPositionFall") && 
        SaveGame.Exists("TimeLeftInDay") &&
        SaveGame.Exists("nextDay")&&
        SaveGame.Exists("currentDay")&&
        SaveGame.Exists("timeInDay")&&
        SaveGame.Exists("StickAmountFall")&&
        SaveGame.Exists("FoodAmountFall"))
        {
            loadButton.SetActive(true);
        }
        else
        {
            loadButton.SetActive(false);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void DeathReturn()
    {
        saveHandler.ResetGame();
        SceneManager.LoadScene(0);
    }
}
