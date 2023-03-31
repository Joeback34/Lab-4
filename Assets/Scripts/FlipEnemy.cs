using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontalVelocity = GetComponent<Rigidbody2D>().velocity.x;

        if(horizontalVelocity > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalVelocity < 0)
        {
            spriteRenderer.flipX = false;
        }
    }
   
    
}
