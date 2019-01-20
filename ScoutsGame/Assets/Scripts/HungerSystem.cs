using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSystem : MonoBehaviour {

    public int hungerLevel = 100;
    public int maxHungerLevel = 100;
    public int hungerRepeatRate = 5;
    public int invokeRate = 5;
    public int ReductionAmount = 2;

    public int foodAmount = 0;

    PickupSys.PickUpHandler pickUpHandler;

	// Use this for initialization
	void Start ()
    {
        pickUpHandler = FindObjectOfType<PickupSys.PickUpHandler>();
        hungerLevel = maxHungerLevel;
	}
	
	// Update is called once per frame
	void Update ()
    {
        foodAmount = pickUpHandler.currentFood;
        while (hungerLevel != 0)
        {
            InvokeRepeating("MinusHunger", invokeRate, hungerRepeatRate);
        }
	}

    public void MinusHunger()
    {
        hungerLevel -= ReductionAmount;
    }

    public void AddFood()
    {
        hungerLevel += 2;
        foodAmount -= 1;
    }
}
