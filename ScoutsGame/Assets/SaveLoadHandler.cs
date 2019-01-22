using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;

public class SaveLoadHandler : MonoBehaviour {

    PickupSys.PickUpHandler pickUpHandler;
    DayNightCycleHandler dayNightCycle;
    public Transform playerTransform;
    public Transform spawnPoint;

    // Use this for initialization
    void Start()
    {
        pickUpHandler = GameObject.FindObjectOfType<PickupSys.PickUpHandler>();
    }

    public void Save()
    {
        SaveResources();
        SaveDayAndTime();
        print("saved");
        SaveGame.Save<Vector3>("PlayerPositionFall", playerTransform.position);
    }

    private void SaveDayAndTime()
    {
        SaveGame.Save<float>("TimeLeftInDay", dayNightCycle.timeLeftInDay);
        SaveGame.Save<int>("nextDay", dayNightCycle.nextDay);
        SaveGame.Save<int>("currentDay", dayNightCycle.currentDay);
        SaveGame.Save<float>("timeInDay", dayNightCycle.timeLeftInDay);
    }

    private void SaveResources()
    {
        SaveGame.Save<int>("StickAmountFall", pickUpHandler.currentSticks);
        SaveGame.Save<int>("FoodAmountFall", pickUpHandler.currentFood);
    }

    public void Load()
    {
        LoadResources();
        LoadTimeAndDay();
        print("loaded");
        playerTransform.position = SaveGame.Load<Vector3>("PlayerPositionFall");
    }

    private void LoadTimeAndDay()
    {
        dayNightCycle.timeLeftInDay = SaveGame.Load<float>("TimeLeftInDay");
        dayNightCycle.nextDay = SaveGame.Load<int>("nextDay");
        dayNightCycle.currentDay = SaveGame.Load<int>("currentDay");
        dayNightCycle.timeInDay = SaveGame.Load<float>("timeInDay");
    }

    private void LoadResources()
    {
        pickUpHandler.currentSticks = SaveGame.Load<int>("StickAmountFall");
        pickUpHandler.currentFood = SaveGame.Load<int>("FoodAmountFall");
    }

    public void ResetGame()
    {
        SaveGame.Delete("StickAmountFall");
        SaveGame.Delete("FoodAmountFall");
        SaveGame.Delete("PlayerPositionFall");
        playerTransform.position = spawnPoint.position;
        pickUpHandler.currentSticks = 0;
        pickUpHandler.currentFood = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
