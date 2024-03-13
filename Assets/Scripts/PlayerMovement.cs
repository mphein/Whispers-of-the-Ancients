using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character controller base from https://www.youtube.com/watch?v=_QajrabyTJc&t=455s&ab_channel=Brackeys

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    const float BASE_SPEED = 8f;
    const float SPRINT_SPEED = 12f;
    public float speed = BASE_SPEED;
    const float gravity = -9.81f;
    const float jumpHeight = 2f;

    const KeyCode SPRINT_KEY = KeyCode.LeftShift;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start() {
        speed = BASE_SPEED;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded) {
            if (Input.GetKey(SPRINT_KEY) && StaminaSystem.staminaSystemInstance.CanSprint()) {
                speed = SPRINT_SPEED;
                StaminaSystem.staminaSystemInstance.Sprint();
            }
            else {
                speed = BASE_SPEED;
                StaminaSystem.staminaSystemInstance.RegainStamina();
            }
            if (velocity.y < 0) velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime * 1.25f;

        controller.Move(velocity * Time.deltaTime);
    }
}
