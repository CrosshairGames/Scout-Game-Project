using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleHandler : MonoBehaviour {

    public Slider timeSlider;
    public float timeLeftInDay = 0.0f;
    public int nextDay = 2;
    public int currentDay = 1;
    public float timeInDay = 10f;
    public Text endOfDayText;
    public GameObject endOfDayObject;
    public GameObject tempEndScreen;
    public bool isDay = true;

	// Use this for initialization
	void Start ()
    {
        timeLeftInDay = timeInDay;
        timeSlider.maxValue = timeInDay;
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
            endOfDayObject.SetActive(true);
            endOfDayText.text = "End of day: " + currentDay;
            print("End of day");
            timeLeftInDay = timeInDay;
            Invoke("StartNewDay", 1); 
        }
    }

    private void StartNewDay()
    {
        for (int i = 2; i > 1; i--)
        {
            currentDay = nextDay;
            nextDay += 1;
            print("added day");
        }
            ResetDay();   
    }

    private void ResetDay()
    {
        print("day reset");
        endOfDayObject.SetActive(false);
        isDay = true;
    }
}
