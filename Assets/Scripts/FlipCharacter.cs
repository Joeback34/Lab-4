using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
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
        moveInput = Input.GetAxisRaw("Horizontal");
        if(moveInput != 0)
        {
            spriteRenderer.flipX = moveInput < 0;
        }
    }
}
