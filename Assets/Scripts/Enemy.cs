using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public Transform playerTransform;
    public float moveSpeed = 3.0f;
    public Animator animator;

    public float damageInterval = 1.5f;

    private bool canDealDamage = true;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if(GameObject.Find("Player") != null)
        {
            playerTransform = GameObject.Find("Player").transform;
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
        
  
        

       
        
          
        
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            animator.SetTrigger("Attack");
            StartCoroutine(DealDamageCoroutine(collision.gameObject));
        }
       
    }   
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopCoroutine(DealDamageCoroutine(collision.gameObject));
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

                yield return new WaitForSeconds(damageInterval);

                canDealDamage = true;
            }

            yield return null;
        }
    }


}
