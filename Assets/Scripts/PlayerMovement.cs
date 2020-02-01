using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float dashdistance = 3f;

    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    
    Vector3 velocity;
    Vector3 move;
    bool isGrounded;
    void Update()
    {
       
        //checking state and applying corresponding variables
        isGrounded = Physics.CheckSphere(groundCheck.position, 
                                         groundDistance, 
                                         groundMask
                                         );
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //movement for the character
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("spacebar jump?");
        }
        //jumping gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
