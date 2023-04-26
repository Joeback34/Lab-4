using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;



public class PlayerController : MonoBehaviour
{
    public bool canRoar;
    public float kCooldown = 2f;
    public float roarTime = 0f;

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
    [SerializeField] float horizontal, vertical;
    private bool hasJumped;
    public bool hasRoared;
    private bool hasFired;
    UnityEvent pausRoarEvent;
    void Start()
    {
        if(pausRoarEvent == null)
        {
            pausRoarEvent = new UnityEvent();
        }
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
        canRoar = true;
    }
    void Jump()
    {
        if (hasJumped && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
            hasJumped = false;
        }
    }
    void Update()
    {
        
        Vector2 movement = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        animator.SetFloat("Speed", (float)Mathf.Abs(horizontal));

        isGrounded = Physics2D.OverlapBox(transform.position, new Vector2(2f, 0.1f), groundLayer);
       
        if (canJump && hasJumped && !isJumping && Time.time > LastJumpTime + jumpCooldown)
        {
            Jump();
            LastJumpTime = Time.time;
            canJump = false;
        }
        
        if (!canJump && Time.time > LastJumpTime + jumpCooldown)
        {
            canJump = true;
        }

        if (hasFired)
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
            hasFired = false;
        }
        else
        {
            animator.SetBool("Attack", false);
        }
        
        animator.SetBool("IsJumping", isJumping);  

        
      


        if (hasRoared && canRoar)
        {
           animator.SetBool("Roar", true);
           canRoar = false;
           roarTime = kCooldown;
           hasRoared = false;
        }
        else
        {
           animator.SetBool("Roar", false);
        }
        if (canRoar == false && roarTime > 0)
        {
            roarTime -= Time.deltaTime;
        }
        if(roarTime <= 0)
        {
            canRoar = true;
        }
        
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

        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            isJumping = false;
        }
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawCube(groundCheck.position, new Vector2(2f, 0.1f));
        Gizmos.DrawCube(transform.position, new Vector2(2f, 0.1f));
    }
    public void OnMove(InputValue value)
    {
        horizontal = value.Get<Vector2>().x;
    }

    public void OnJump()
    {
        hasJumped = true;
    }

    public void OnFire()
    {
        hasFired = true;
    }

    public void OnRoar()
    {
        hasRoared = true;
    }


}



