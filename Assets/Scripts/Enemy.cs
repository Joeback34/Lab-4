using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3.0f;
    
   
   
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.Find("Player").transform; // players transform the enemy will follow
    }

    void Update()
    {
        // Calculate the direction towards the player
        Vector2 direction = playerTransform.position - transform.position;

        // Normalize the direction to get a unit vector
        direction.Normalize();

        // Move towards the player
        rb.velocity = direction * moveSpeed;
    }
    
}
