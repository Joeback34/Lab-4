using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with this enemy and is above it
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject); // Destroy the game object this script is attached to
        }
    }
}