using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour
{
    bool canJump = true;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer, enemyLayer;
    public int maxJumps = 1;
    public Animator animator;
    public bool isColliding;
    public bool inAir;
    float jumpDelay = 1f;
    float jumpTimer = 0f;
    private Collider2D[] results; 
    private int jumpsRemaining;
    private Rigidbody2D rb;
    [SerializeField] bool isGrounded = true;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        
    }

    void Update()
    {
        float deltaTime = Time.deltaTime;
        if (!canJump)
        {
            jumpTimer -= deltaTime;
            if (jumpTimer <= 0)
            {
                canJump = true;
            }
        }

        if (canJump && Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
        void Jump()
        {
            canJump = false;
            jumpTimer = jumpDelay;
        }


        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(2f, 0.1f), groundLayer);



        if (Input.GetKey(KeyCode.Space) && isGrounded && jumpsRemaining > 0)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jumpsRemaining--;
            isGrounded = false;
            animator.SetBool("IsJumping", true);

        }
    
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            results = Physics2D.OverlapCircleAll(GetComponent<Attack>().attackLocation.position, .3f, enemyLayer);
            animator.SetBool("Attack", true);
            
            foreach (Collider2D collider2D in results)
            {
                if(collider2D.GetComponent<Health>() != null && collider2D.name != "Player")
                {
                    collider2D.GetComponent<Health>().TakeDamage(25);
                }
            }
        }
        else
        {
            animator.SetBool("Attack", false);
        }
        


        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetTrigger("IsJumping");
        }

       
        
         
       
    }   

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            jumpsRemaining = maxJumps;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Meat"))
        {
            GetComponent<Health>().TakeDamage(-25);
           
        }
    }

   

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(groundCheck.position, new Vector2(2f, 0.1f));
    }

}

