using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    float speed = 10;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0f;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GetInput();
    }

    void Movement()
    { 
        if (controller.isGrounded)
        {
            if (Input.GetKey (KeyCode.W))
            {
                if (animator.GetBool("Attacking") == true)
                {
                    return;
                }
                else if (animator.GetBool ("Attacking") == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetInteger("Condition", 1);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= speed;
                    moveDir = transform.TransformDirection(moveDir);
                }
            }
            else
            {
                animator.SetBool("Running", false);
                animator.SetInteger("Condition", 0);
                moveDir = new Vector3(0, 0, 0);
                
            }
        }
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity* Time.deltaTime;
        controller.Move(moveDir* Time.deltaTime);
    }

    void GetInput()
    {
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (animator.GetBool ("Running") == true)
                {
                    animator.SetBool("Running", false);
                    animator.SetInteger("Condition", 0);
                }
                if (animator.GetBool("Running") == false)
                {
                    Attack();
                }
            }
        }
    }

    void Attack() 
    {
        
        StartCoroutine (AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        animator.SetBool("Attacking", true);
        animator.SetInteger("Condition", 2);
        yield return new WaitForSeconds(1);
        animator.SetInteger("Condition", 0);
        animator.SetBool("Attacking", false);
    }
}
