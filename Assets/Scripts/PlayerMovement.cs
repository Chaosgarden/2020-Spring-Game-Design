using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem dashParticle;
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
        //controller.Move(velocity * Time.deltaTime);
     

        HandleMovementInput();
        HandleRotationInput();
        HandleDash();
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
    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        if (canDash)
        {
            float dashDistance = 10f;
            transform.position += transform.forward * dashDistance;

            dashParticle.Play();
        }
        canDash = false;
        yield return new WaitForSeconds(2f);
        canDash = true;

    }
}
