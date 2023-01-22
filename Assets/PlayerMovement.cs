using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool landed = false;
    bool inAir = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            inAir = true;
            animator.SetBool("Jump", jump);
 
        }
      
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        animator.SetBool("Jump", false);
    }

    public void OnLanding()
    {
        Debug.Log("Landing");
        landed = true;
        animator.SetBool("Landed", landed);
       
    }
}
