using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("InputChecks")]
    bool moveLeft;
    bool moveRight;

    public bool canJump;

    [Header("MovementVariables")]
    int horizontalInput;
    public float moveSpeed;

    public float jumpHeight;
    int jumpCount;
    public int extraJumpLimit;
    bool isGrounded;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    void Update()
    {
        ReadInputs();
        Move(moveSpeed);
        Jump(jumpHeight);
        LimitJump();
    }
    public void ReadInputs()
    {
        if (Input.GetKey(KeyCode.D))
        {
            moveRight = true;
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveLeft = true;
            horizontalInput = -1;
        }
        else
        {
            moveRight = false;
            moveLeft = false;
            horizontalInput = 0;

        }
    }
   
    public void Move(float moveSpeed)
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    public void Jump(float jumpHeight)
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumpCount++;
            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void LimitJump()
    {
        if(isGrounded == false)
        {
            if(jumpCount > extraJumpLimit)
            {
                canJump = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "leaf")
        {
            isGrounded = true;
            canJump = true;
            jumpCount = 0;
        }
    }
}
