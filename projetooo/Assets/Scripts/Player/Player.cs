using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 6f;
    private int jump2 = 2;
    private BoxCollider2D bc2d;
    [SerializeField] private LayerMask groundLayer;
    
    [Header("Flip Settings")]
    public bool facingRight = true; // Direção inicial do personagem
    private SpriteRenderer spriteRenderer;


    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
            
            // Flip para a direita
            if (!facingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
            
            // Flip para a esquerda
            if (facingRight)
            {
                Flip();
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y); // Stop horizontal movement but preserve vertical velocity
        }
        // float horizontalInput = Input.GetAxis("Horizontal");
        // rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);

    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        }
    }

    public bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return ground.collider != null;
    }

    void Flip()
    {
        // Inverte a direção
        facingRight = !facingRight;
        
        // Vira o sprite horizontalmente
        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = !facingRight;
        }
    }



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();
    }


}
