using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private float playerSpeed = 0f;
    private bool isGrounded;
    public float speed = 5f;
    public float sprintMult = 2f;
    public float gravity = 9.8f;
    public float drag = 0.999f;
    public float jumpHeight = 1f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // Receives input from InputManager and moves the player accordingly
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * playerSpeed * Time.deltaTime);
        playerVelocity.y += -gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0) {
            playerSpeed = speed; 
            playerVelocity.y = -2f;
        } else if(!isGrounded) {
            playerSpeed *= drag;
        }        
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log("Player velocity: " + playerVelocity.y);
    }

    public void Jump()
    {
        if(isGrounded) {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * -gravity);
        }
    }

    public void Sprint()
    {
        speed *= sprintMult;
    }

    public void StopSprint()
    {
        speed /= sprintMult;
    }
}
