using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int maxJumps = 1;
    public Animator animator;
    public bool isColliding;
    public bool inAir;

    private List<Collider2D> results; 
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
            isColliding = Physics2D.OverlapCircle(groundCheck.position, .1f, ContactFilter2D., 5);
            animator.SetBool("Attack", true);
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
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(groundCheck.position, new Vector2(2f, 0.1f));
    }

}

