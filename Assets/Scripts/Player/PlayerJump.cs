using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpDelay = 0.5f;
    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canJump && Input.GetKey(KeyCode.Space))
        {
            canJump = false;
            Invoke("JumpWithDelayTime", jumpDelay);
        }

    }

    void JumpWithDelayTime()
    {
        Jump();
        canJump = true;
    }

    void Jump()
    {
        Input.GetKey(KeyCode.Space);
    }
}
