using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletorBehaviour : MonoBehaviour
{
    float speed = 1f;
    float velocityY;
    float rot = 0f;
    float rotSpeed = 80f;
    float gravity = -8f;
    float jumpHeight = 4f;
    bool isFalling = true;
    float currentSpeed = 0;

    Vector3 velocity = Vector3.zero;

    CharacterController controller;
    Animator anim;
 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
           
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("is grounded:" + controller.isGrounded);
        velocityY += gravity * Time.deltaTime;
        velocity = transform.forward * currentSpeed + Vector3.up * velocityY;


        if (controller.isGrounded)
        {
            if (!isFalling)
            {
                velocityY = 0;

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    Attack();
                } else
                {
                    anim.SetInteger("attack", 0);

                }

                MovePlayer();
            }
            else
            {
                Land();
                isFalling = false;
            }

        } else
        {
            Fall();
            isFalling = true;
        }

       
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        controller.Move(velocity * Time.deltaTime);
    }


    private void Jump()
    {
        isFalling = true;
        anim.SetInteger("jump", 1);
        float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
        velocityY = jumpVelocity;
    }

    private void Fall()
    {
       anim.SetInteger("jump", 2);
       
    }

    private void Land()
    {
        anim.SetInteger("jump", 3);
    }

    private void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("walk", 1);
            currentSpeed = 2f;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("walk", 2);
            currentSpeed = -2f;
        }

        else if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            anim.SetInteger("walk", 0);
            currentSpeed = 0;
           // velocity = Vector3.zero;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Attack()
    {
        anim.SetInteger("attack", 1);
              
    }
}
