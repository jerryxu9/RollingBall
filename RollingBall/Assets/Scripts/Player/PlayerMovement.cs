using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    public float MoveSpeed;
    public float JumpSpeed;
    private int extraJumps;
    public int extraJumpsValue;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Check for allowed jump value and perform jumping
    /// </summary>
    private void Update()
    {
        if (isGrounded)
            extraJumps = extraJumpsValue;

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rigidbody.velocity = Vector2.up * JumpSpeed;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded)
        {
            rigidbody.velocity = Vector2.up * JumpSpeed;
        }

        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rigidbody.velocity = Vector2.up * JumpSpeed;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded)
        {
            rigidbody.velocity = Vector2.up * JumpSpeed;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    /// <summary>
    /// Move and flip the player. Check if player lands on a platform constantly
    /// </summary>
    private void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            rigidbody.velocity = new Vector2(MoveSpeed, rigidbody.velocity.y);
            if (!facingRight)
                Flip();
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rigidbody.velocity = new Vector2(-MoveSpeed, rigidbody.velocity.y);
            if (facingRight)
                Flip();
        }
    }

    /// <summary>
    /// Purpose: for SpeedPlatforms to move
    /// </summary>
    public void PlatformMove(float horizontalSpeed)
    {
        rigidbody.velocity = new Vector2(horizontalSpeed, rigidbody.velocity.y);
    }
}
