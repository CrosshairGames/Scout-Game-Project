using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleHandler : MonoBehaviour {

    [Header("End of day settings")]
    public Text endOfDayTextEF;
    public Text endOfDayTextNEF;
    public GameObject endOfDayObjectEF;
    public GameObject endOfDayObjectNEF;
    public GameObject tempEndScreen;

    [Header("Time settings")]
    public Slider timeSlider;
    public float timeLeftInDay = 0.0f;
    public float timeInDay = 10f;

    [Header("Day Settings")]
    public int nextDay = 2;
    public int currentDay = 1;
    public bool isDay = true;

    [Header("Win/Lose conditions")]
    [Range(0,2)]public int playerWon = 0;
    public int foodRequiredInDay;
    PickupSys.PickUpHandler pickupHandle;

	// Use this for initialization
	void Start ()
    {
        timeLeftInDay = timeInDay;
        timeSlider.maxValue = timeInDay;
        pickupHandle = FindObjectOfType<PickupSys.PickUpHandler>();
    }

	
	// Update is called once per frame
	void Update ()
    {
        CheckDay();
    }

    private void CheckDay()
    {
        if (isDay)
        {
            timeLeftInDay -= Time.deltaTime;
            timeSlider.value = timeLeftInDay;
        }

        if (timeLeftInDay <= 0)
        {

            isDay = false;
            timeLeftInDay = timeInDay;
            CheckFoodAmount();
            switch (playerWon)
            {
                case 1:
                    print("End of day");
                    endOfDayObjectEF.SetActive(true);
                    endOfDayTextEF.text = "End of day: " + currentDay;
                    Invoke("StartNewDay", 1);   
                    break;
                case 2:
                    print("player lost");
                    endOfDayObjectNEF.SetActive(true);
                    endOfDayTextNEF.text = "You have Died, current day: " + currentDay;
                    break;
            }
        }
    }

    private void StartNewDay()
    {
        currentDay = nextDay;
        nextDay += 1;
        print("added day");
        ResetDay();   
    }

    private void CheckFoodAmount()
    {
        if (pickupHandle.currentFood < foodRequiredInDay)
        {
            print("Player Loses");
            playerWon = 2;
        }
        else if (pickupHandle.currentFood >= foodRequiredInDay)
        {
            print("player survives");
            playerWon = 1;
        }
    }

    private void ResetDay()
    {
        print("day reset");
        endOfDayObjectEF.SetActive(false);
        isDay = true;
    }
}
