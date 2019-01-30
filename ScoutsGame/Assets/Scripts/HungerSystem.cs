using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerSystem : MonoBehaviour {

    public int foodGathered;
    public bool doHunger;
    public int foodRequiredInDay = 0;

    public Text reqFoodText;

    PickUpHandler pickUpHandler;
    DayNightCycleHandler cycleHandler;

    private void Awake()
    {
        try
        {
        doHunger = GameObject.FindObjectOfType<GameSettings>().hungerEnabled;
        foodRequiredInDay = GameObject.FindObjectOfType<GameSettings>().foodNeeded;
        }
        catch (FormatException e)
        {
            Debug.LogError(e.Message);
        }

    }

    // Use this for initialization
    void Start ()
    {
        pickUpHandler = FindObjectOfType<PickUpHandler>();
        cycleHandler = FindObjectOfType<DayNightCycleHandler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        foodGathered = pickUpHandler.currentFood;
        reqFoodText.text = "Food Needed: " + foodRequiredInDay;
        if (doHunger)
        {
            if(!cycleHandler.isDay)
            {
                CheckFoodAmount();
            }
        }
	}

    private void CheckFoodAmount()
    {
        if (pickUpHandler.currentFood < foodRequiredInDay)
        {
            print("Player Loses");
            cycleHandler.playerWon = 2;
        }
        else if (pickUpHandler.currentFood >= foodRequiredInDay)
        {
            print("player survives");
            cycleHandler.playerWon = 1;
        }
    }
}
