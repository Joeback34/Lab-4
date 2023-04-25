using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : Health
{
    private void Start()
    {
       

    }

    public int Heal;
    void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask playerLayer = LayerMask.NameToLayer("Player");
        LayerMask HealthLayer = LayerMask.NameToLayer("Meat");

        
        if (collision.gameObject.layer == playerLayer)
        {
            if (maxHealth == 100f)
            {
                Physics2D.IgnoreLayerCollision(playerLayer, HealthLayer);
            }
        }

        // Check if the player collided with this enemy and is above it
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject); // Destroy the game object this script is attached to
        }
    }

    private void Update()
    {
       
      
    }
}