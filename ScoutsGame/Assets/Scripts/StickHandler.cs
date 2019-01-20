using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PickupSys
{
    public class StickHandler : MonoBehaviour
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
            GameObject.FindObjectOfType<PickUpHandler>().AddResource("Stick", 1);
            Destroy(gameObject);
        }
        /*
        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.E))
            {
                GameObject.FindObjectOfType<PickUpHandler>().AddResource("Stick", 1);
                Destroy(gameObject);
            }
        }
        */
    }
}
