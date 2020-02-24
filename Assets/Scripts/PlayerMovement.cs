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
    public Animator animator;
    public bool isAttacking = false;
    bool canDash = true;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float groundDistance = 0.4f;
    float rollSpeed = 0;
    Vector3 rollDirection;
    Vector3 velocity;
    Vector3 move;
    bool isGrounded;
    public int time = 0;
    void FixedUpdate()
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

        /*float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("spacebar jump?");
        }
        //jumping gravity
        */
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
     

        HandleMovementInput();
        HandleRotationInput();
        HandleInputRoll();
        HandleRoll();

    }
    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        if (movement != Vector3.zero && !isAttacking)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            animator.SetInteger("condition", 1);
        }
        else
        {
            animator.SetInteger("condition", 0);
        }
    }
    void HandleRotationInput()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    void HandleInputRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rollSpeed = 100f;
            rollDirection = transform.forward;
            animator.SetInteger("condition", 3);
        }
    }
    void HandleRoll()
    {
        transform.position += rollDirection * rollSpeed * Time.deltaTime;
        rollSpeed -= rollSpeed * 5f * Time.deltaTime;
        if (rollSpeed < 5f)
        {
            animator.SetInteger("condition", 0);
        }
    }
}
