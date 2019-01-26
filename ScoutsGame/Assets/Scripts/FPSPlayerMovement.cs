using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerMovement : MonoBehaviour {

    public float walkSpeed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float runSpeed = 8.0F;
    public float gravity = 20.0F;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 negMoveDirection = Vector3.zero;
    private Vector3 StraifeDirection = Vector3.zero;
    private CharacterController controller;
    private GameObject FPSCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        FPSCamera = GameObject.FindGameObjectWithTag("FPSCamera");
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(FPSCamera.transform.forward);
            StraifeDirection = transform.TransformDirection(FPSCamera.transform.right);
            negMoveDirection = transform.TransformDirection(-FPSCamera.transform.forward);

            moveDirection *= walkSpeed;
            StraifeDirection *= walkSpeed;
            negMoveDirection *= walkSpeed;

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        negMoveDirection.y -= gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(moveDirection * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(negMoveDirection * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(StraifeDirection * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(-StraifeDirection * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed *= runSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 6.0f;
        }
    }
}
