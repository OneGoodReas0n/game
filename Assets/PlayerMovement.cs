using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool inTheAir = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetAxisRaw("Vertical") == 1 && !inTheAir)
        {
            jump = true;
            inTheAir = true;
            animator.SetBool("Jump", jump);
            animator.SetBool("InAir", inTheAir);
        }
        
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            crouch = true;
            animator.SetBool("Crouch", crouch);
        } else if(Input.GetAxisRaw("Vertical") == 0)
        {
            crouch = false;
            animator.SetBool("Crouch", crouch);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        animator.SetBool("Jump", jump);
    }

    public void OnLanding()
    {
        inTheAir = false;
        animator.SetBool("InAir", inTheAir);
    }

    public void OnCrouching()
    {
        animator.SetBool("Crouch", false);
    }
}
