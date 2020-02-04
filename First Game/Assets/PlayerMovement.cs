using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool isJumping = false;
    bool isCrouching = false;

    public float climbSpeed = 10f;
    float verticalMove = 0f;
    bool isClimbing = false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        } else if(Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }

        if(Input.GetButtonDown("Vertical"))
        {
            isClimbing = true;
            verticalMove = Input.GetAxisRaw("Vertical") * climbSpeed;
        }
        else if (Input.GetButtonUp("Vertical"))
        {
            isClimbing = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping, isClimbing, verticalMove * Time.fixedDeltaTime);

        isJumping = false;
    }
}
