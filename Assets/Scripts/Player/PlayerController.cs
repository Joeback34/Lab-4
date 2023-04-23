using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour
{
    bool isJumping = false;
    bool canJump = true;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer, enemyLayer;
    public Animator animator;
    public bool inAir = false;

    public float jumpCooldown = 1.0f;
    public float LastJumpTime = 0.0f;
    private Collider2D[] results;
    private Rigidbody2D rb;
    [SerializeField] bool isGrounded = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }
    void Update()
    {


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundLayer);
        {
            if(hit.collider != null)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        isGrounded = Physics2D.OverlapBox(transform.position, new Vector2(2f, 0.1f), groundLayer);
        
        inAir = !isGrounded;

        if (inAir)
        {
            isGrounded = false;
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space) && !isJumping && Time.time > LastJumpTime + jumpCooldown)
        {
            Jump();
            LastJumpTime = Time.time;
            canJump = false;
        }
        
        if (!canJump && Time.time > LastJumpTime + jumpCooldown)
        {
            canJump = true;
        }


        if (Input.GetKeyDown(KeyCode.J))
        {

            results = Physics2D.OverlapCircleAll(GetComponent<Attack>().attackLocation.position, .3f, enemyLayer);
            animator.SetBool("Attack", true);

            foreach (Collider2D collider2D in results)
            {
                if (collider2D.GetComponent<Health>() != null && collider2D.name != "Player")
                {
                    collider2D.GetComponent<Health>().TakeDamage(25);
                }
            }
        }
        else
        {
            animator.SetBool("Attack", false);
        }

        animator.SetBool("IsJumping", isJumping);
    }



   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Meat"))
        {
            GetComponent<Health>().TakeDamage(-25);
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
        }

    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(groundCheck.position, new Vector2(2f, 0.1f));
        Gizmos.DrawCube(transform.position, new Vector2(2f, 0.1f));
    }
}


