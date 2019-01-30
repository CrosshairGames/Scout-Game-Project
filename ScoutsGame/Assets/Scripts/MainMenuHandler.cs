using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using BayatGames.SaveGameFree;

public class MainMenuHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void RunStartGame(int index)
    {
        if (SaveGame.Exists("PlayerPositionFall") && SaveGame.Exists("TimeLeftInDay")
            && SaveGame.Exists("nextDay")
            && SaveGame.Exists("currentDay")
            && SaveGame.Exists("timeInDay"))
        {
            StartGame(index);
        }
        else
        {
            print("No save found");
        }
    }
    public void StartGame(int sceneIndex)
    { 
            SceneManager.LoadScene(sceneIndex);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
