using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_TPS_Controller : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    public float dashSpeed = 5;
    private bool facingRight = true;
    private Rigidbody2D rb;
    public bool isGrounded;
    public LayerMask groundLayer;
    //private Collision coll
    public float collisionRadius = 0.25f;
    public Vector2 bottomOffset, rightOffset, leftOffset;

    void Start()
    {
        //coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        //player movement 
        
        //player dash
        if(Input.GetButtonDown("Dash"))
        {
            Dash(1,1);
        }
        
        //player jump
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            Jump();
        }

    }

    private void Walk(Vector2 dir)
    {
        rb.linearVelocity = (new Vector2(dir.x * speed, rb.linearVelocity.y));
    }

    private void Jump()
    {
        Debug.Log("I am jumping");
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.linearVelocity += Vector2.up * jumpForce;
    }

    private void Dash(float x, float y)
    {
        rb.linearVelocity = Vector2.zero;
        Vector2 dir = new Vector2(x, y);

        rb.linearVelocity += dir.normalized * dashSpeed;
    }

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

