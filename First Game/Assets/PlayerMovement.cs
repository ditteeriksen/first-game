using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool isJumping = false;
    bool isCrouching = false;


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; 

        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        if(Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
        } else if(Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
        }
    }

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouching, isJumping);

        isJumping = false;
    }
}
