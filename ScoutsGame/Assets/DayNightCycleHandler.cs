using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycleHandler : MonoBehaviour {

    public Slider timeSlider;
    public float timeLeftInDay = 0.0f;
    public int days = 0;
    public float timeInDay = 10f;
    public Text endOfDayText;
    public GameObject endOfDayObject;
    public GameObject tempEndScreen;
    public bool isDay = true;

	// Use this for initialization
	void Start ()
    {
		
	}

    public void DayTime()
    {
        if (isDay == true)
        {
            timeLeftInDay += 0.1f / timeInDay;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        InvokeRepeating("DayTime", 1, timeInDay);
        if (timeLeftInDay >= 1.0f)
        {
            EndDay();
            print("Day is done");
        }

        if (days == 5)
        {
            tempEndScreen.SetActive(true);
        }

        timeSlider.value = timeLeftInDay;
	}

    private void EndDay()
    {
        isDay = false;
        endOfDayObject.SetActive(true);
        CancelInvoke("DayTime");
        endOfDayText.text = "End of day. Current day: " + days;
        Invoke("StartNewDay", 10);
    }

    private void StartNewDay()
    {
        days += 1;
        timeLeftInDay = 0;
        endOfDayObject.SetActive(false);
        isDay = true;
        print("new day starting");
    }
}
