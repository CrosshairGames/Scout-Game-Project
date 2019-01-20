using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;

    public KeyCode forward = KeyCode.W;
    public KeyCode backward = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    CharacterController controller;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //speed = speed * Time.deltaTime;

        if (Input.GetKey(forward))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(backward))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(left))
        {
            transform.Translate(0, 0, -speed);
        }
        if (Input.GetKey(right))
        {
            transform.Translate(0, 0, speed);
        }
    }
}
