using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipCharacter : MonoBehaviour
{
    public bool IsFacingRight;
    
    private SpriteRenderer spriteRenderer;
    private float moveInput;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }

        if(moveInput > 0)
        {
            IsFacingRight = true;
        }
        else if(moveInput < 0)
        {
            IsFacingRight = false;
        }
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().x;
        
    }

}