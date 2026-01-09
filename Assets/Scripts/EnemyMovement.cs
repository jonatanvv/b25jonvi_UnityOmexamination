using UnityEngine;

public class SideToSideMover : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 3f;             // Movement speed
    public Transform leftPoint;           // Left boundary
    public Transform rightPoint;          // Right boundary

    private bool movingRight = true;      // Current movement direction
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        FlipSprite();
    }

    void Move()
    {
        // Determine target direction
        if (movingRight)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

            // Check if we reached the right boundary
            if (transform.position.x >= rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            rb.linearVelocity = new Vector2(-speed, rb.linearVelocity.y);

            // Check if we reached the left boundary
            if (transform.position.x <= leftPoint.position.x)
            {
                movingRight = true;
            }
        }
    }

    void FlipSprite()
    {
        // Flip sprite based on movement direction
        if (movingRight)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }
}
