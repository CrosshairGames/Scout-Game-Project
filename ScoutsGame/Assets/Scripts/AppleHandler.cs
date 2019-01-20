using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickupSys
{
    public class AppleHandler : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnMouseDown()
        {
            GameObject.FindObjectOfType<PickUpHandler>().AddResource("Apple", 1);
            Destroy(gameObject);
        }
    }
}
