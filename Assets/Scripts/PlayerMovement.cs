using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool landed = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.Space) && landed)
        {
            jump = true;
            landed = false;
            animator.SetBool("Jump", jump);
            animator.SetBool("Landed", landed);

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
        landed = true;
        animator.SetBool("Landed", landed);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.name.Contains("saw"))
        {
            animator.Play("Dead");
            Debug.Log("Dead");
            //Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("press_moves") && landed)
        {
            animator.Play("Dead");
            Debug.Log("Dead");
            //Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("press_static") && landed)
        {
            animator.Play("Dead");
            Debug.Log("Dead");
            //Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("ray"))
        {
            animator.Play("Dead");
            Debug.Log("Dead");
            //Destroy(gameObject);
        }
    }
}
