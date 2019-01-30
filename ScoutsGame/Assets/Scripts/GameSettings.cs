using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public bool hungerEnabled = true;
    public bool enemyAiEnabled = true;
    public bool dayCycleEnabled = true;
    public int foodNeeded = 8;
    public bool continuedPastGame = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetContinuedGame(bool setting)
    {
        continuedPastGame = setting;
    }

    public void SetHunger(bool setting)
    {
        hungerEnabled = setting;
    }

    public void SetEnemyAi(bool setting)
    {
        enemyAiEnabled = setting;
    }

    public void SetDayCycle(bool setting)
    {
        dayCycleEnabled = setting;
    }

    public void SetFoodNeeded(string setting)
    {
        foodNeeded = Int32.Parse(setting);
    }
}
