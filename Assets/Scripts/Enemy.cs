using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform playerTransform;
    public float moveSpeed = 3.0f;
    public Animator animator;
    public float attackTime = 0f;
    public float damageInterval = 1.5f;
    private PlayerController playerController;
    Coroutine attackCoroutine;
    private bool isPaused = false;
    private bool canDealDamage = true;
    private Rigidbody2D rb;
    public bool isStillColliding = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
               playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        }

     
    }
    void Update()
    {
        // Calculate the direction towards the player
        
        if (playerTransform != null)
        {
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();

            rb.velocity = direction * moveSpeed;
        }

        attackTime -= Time.deltaTime;

        if(attackTime <= 0)
        {
            attackTime = 0;
            canDealDamage = true;
        }
        else
        {
            canDealDamage = false;
        }


        if(playerController != null && playerController.hasRoared && isPaused == false)
        {
            isPaused = true;
           
            StartCoroutine(PauseMovement());
        }
        else
        {
            isPaused = false;
        }

        

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("Attack");
            attackCoroutine = StartCoroutine(DealDamageCoroutine(collision.gameObject));
            isStillColliding = true;
        }
        
    }   
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines();
            isStillColliding = false;
        }
    }   
    private IEnumerator DealDamageCoroutine(GameObject player)
    {
        while (true)
        {
            if (canDealDamage && player != null)
            {
                player.GetComponent<Health>().TakeDamage(25);

                canDealDamage = false;

                attackTime = damageInterval;

                yield return new WaitForSeconds(damageInterval);
            }
            if (!isStillColliding)
            {
                yield return null;
            }
            yield return null;
        }
    }

    private IEnumerator PauseMovement()
    {
        moveSpeed = 0f;
        Debug.Log("IsPaused");
        yield return new WaitForSeconds(2);

        moveSpeed = 5f;
        isPaused = false;

    }

}
