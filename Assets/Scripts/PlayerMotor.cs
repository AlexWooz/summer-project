using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float vSpeed = 0;
    private bool jump;
    public float speed = 5f;
    public float gravity = 9.8f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded) {
            if (jump) {
                vSpeed = 5;
                jump = false;
            }
        } else {
            vSpeed -= gravity * Time.deltaTime;
        }
    }

    // Receives input from InputManager and moves the player accordingly
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x * speed;
        moveDirection.y = vSpeed;
        moveDirection.z = input.y * speed;
        controller.Move(transform.TransformDirection(moveDirection) * Time.deltaTime);
    }

    public void Jump()
    {
        if(controller.isGrounded) {
            jump = true;
        }
    }

}
