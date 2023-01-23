using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Transform wallGrabPoint;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private Rigidbody2D rigidbody;

    public CharacterController controller;
    public Animator animator;

    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump, isGrounded, canGrab, isGrabbing = false;
    float gravityValue;
    float wallJumpTime = .2f;
    float wallJumpCounter = .2f;


    private void Start()
    {
        gravityValue = rigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {

        if (wallJumpCounter <= 0)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !jump)
            {
                jump = true;
                isGrounded = false;
                animator.SetBool("Jump", jump);
                animator.SetBool("Landed", isGrounded);

            }

            canGrab = Physics2D.OverlapCircle(wallGrabPoint.position, .2f, whatIsWall);

            isGrabbing = false;

            if (canGrab && !isGrounded)
            {
                if ((transform.localScale.x == 2f && Input.GetAxisRaw("Horizontal") > 0) || (transform.localScale.x == -2f && Input.GetAxisRaw("Horizontal") < 0))
                {
                    isGrabbing = true;
                }
            }

            if (isGrabbing)
            {
                rigidbody.gravityScale = 0f;
                rigidbody.velocity = Vector2.zero;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    wallJumpCounter = wallJumpTime;
                    rigidbody.gravityScale = gravityValue;
                    rigidbody.velocity = new Vector2(-Input.GetAxisRaw("Horizontal") * horizontalMove, 20f);
                    isGrabbing = false;
                }

            }
            else
            {
                rigidbody.gravityScale = gravityValue;
            }
        }
        else
        {
            wallJumpCounter -= Time.deltaTime;
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
        isGrounded = true;
        animator.SetBool("Landed", isGrounded);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if(collision.gameObject.name.Contains("saw"))
        {
            animator.Play("Dead");
            Debug.Log("Dead");
            //Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("press_moves") && isGrounded)
        {
            animator.Play("Dead");
            Debug.Log("Dead");
            //Destroy(gameObject);
        }

        if (collision.gameObject.name.Contains("press_static") && isGrounded)
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
