using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;

    private bool facingRight = true;
    private Rigidbody2D rb;
    
    
    private Animator animation;
    

    
    

    private bool isGrounded;
    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;
        animation = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            flip();
        } 
        else if (facingRight == true && moveInput < 0) 
        {
            flip();
        }
        if (moveInput==0)
        {
            animation.SetBool("run", false);
        }
        else
        {
            animation.SetBool("run", true);
        }

    }

    private void Update()

    {
        animation = GetComponent<Animator>();
        if (isGrounded == true) 
        {
            animation.SetBool("IsJumping", false);
            extraJumps = extraJumpValue;
            
        }
        else
        {
            animation.SetBool("IsJumping", true);
        }
        
    
        if (Input.GetKeyDown(KeyCode.Space)  && isGrounded == true)
        {
            
            

            rb.velocity = Vector2.up * jumpForce;
            animation.SetTrigger("prejump");

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0&& isGrounded == false)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            animation.SetTrigger("prejump");

        }

    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (moveInput < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}


