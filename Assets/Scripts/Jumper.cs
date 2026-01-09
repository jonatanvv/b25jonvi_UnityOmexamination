using UnityEngine;

public class StationaryJumper : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 8f;
    public float jumpInterval = 2f;       // Average time between jumps
    public bool randomizeInterval = true; // Add some randomness

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;
    private float jumpTimer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ResetJumpTimer();
    }

    void Update()
    {
        CheckGround();
        HandleJumping();
        UpdateAnimations();
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void HandleJumping()
    {
        if (isGrounded)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                ResetJumpTimer();
            }
        }
    }

    void ResetJumpTimer()
    {
        jumpTimer = randomizeInterval 
            ? Random.Range(jumpInterval * 0.5f, jumpInterval * 1.5f) 
            : jumpInterval;
    }

    void UpdateAnimations()
    {
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalSpeed", rb.linearVelocity.y);
    }
}
