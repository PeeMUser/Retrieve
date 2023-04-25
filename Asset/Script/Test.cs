using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour
{
    public float movepseed;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    // Awake is called after all objects are initiated. Called in render order
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //will look for a component on this GameObject (what is attached to to) of type rigidbody2D
    }

    // Update is called once per frame
    void Update()
    {
        // get player input
        ProcessInputs();
        //animate
        Animate();
    }
    private void FixedUpdate()
    {
        //move
        Move();
    }
    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * movepseed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;
    }
    private void Animate()
    {
        if (moveDirection > 0 && !facingRight)
        {
            flipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            flipCharacter();
        }
    }
    private void ProcessInputs()
    {
        moveDirection = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }
    private void flipCharacter()
    {
        facingRight = !facingRight; //inversion bool
        transform.Rotate(0f, 180f, 0f);
    }
}
