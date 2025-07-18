using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 6f;
    private float nJump;
    private BoxCollider2D bc2d;
    // private Animator anime;
    // private int runHash = Animator.StringToHash("mpRunning");
    // private int jumpHash = Animator.StringToHash("mpJumping");
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        // anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        
        // anime.SetBool(runHash, rb.linearVelocity.x != 0);
        // anime.SetBool(jumpHash, !isGrounded());
    }

    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);
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
        if (isGrounded())
        {
            nJump = 2; // Reset jump count when grounded
        }
        if (Input.GetKeyDown(KeyCode.W) && nJump > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            nJump--;
        }
    }



    private bool isGrounded()
    {
        RaycastHit2D ground = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, 0.01f, groundLayer);
        return ground.collider != null;
    }


}
