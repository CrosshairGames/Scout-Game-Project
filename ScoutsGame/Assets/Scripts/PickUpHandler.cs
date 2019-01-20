using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BayatGames.SaveGameFree.Types;

namespace PickupSys
{
    public class PickUpHandler : MonoBehaviour {

        public Text stickText;
        public Text appleText;

        public int currentSticks = 0;
        public int currentFood = 0;

        // Use this for initialization
        void Start()
        {
            stickText.text = "Sticks: 0";
            appleText.text = "Apples: 0";
        }

        // Update is called once per frame
        void Update()
        {
            stickText.text = "Sticks: " + currentSticks;
            appleText.text = "Apples: " + currentFood;
        }


        public void AddResource(string resourceType, int numOfResource)
        {
            if (resourceType == "Stick" && numOfResource != 0)
            {
                currentSticks += numOfResource;
            }
            if (resourceType == "Apple" && numOfResource != 0)
            {
                currentFood += numOfResource;
            }
        }
    }
}
