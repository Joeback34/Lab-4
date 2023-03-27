using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed = 3.0f;
    public float itemDropChance = 0.2f;
    public GameObject itemPrefab;

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
     public GameObject itemToSpawn; // The item to spawn when the enemy is destroyed

    private void OnDestroy()
    {
        if (Random.value <= itemDropChance)
        {
            Instantiate(itemToSpawn, transform.position, Quaternion.identity); // Spawn the item at the enemy's position
        }
    }
           

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with this enemy and is above it
        if (collision.gameObject.tag == "Player" && collision.transform.position.y > transform.position.y)
        {
            Destroy(gameObject); // Destroy the game object this script is attached to
        }
    }

     

}
