using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    private Rigidbody2D rb;
    private float horizontal;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float dragFactor;
    [SerializeField] private float airDrag;
    [SerializeField] private float jumpTime;
    private float jumpTimeCounter;
    private bool isJumping;
    [SerializeField] private float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (horizontal != 0f && rb.velocity.x < maxVelocity && rb.velocity.x > -maxVelocity)
        {
            rb.AddForce(new Vector2(horizontal * speed * Time.deltaTime,0),ForceMode2D.Impulse);
        } else if (!IsGrounded())
        {
            if (rb.velocity.x > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x - airDrag, rb.velocity.y);
            }
            if (rb.velocity.x < 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x + airDrag, rb.velocity.y);
            }
        }
        if (IsGrounded())
        {
            if (rb.velocity.x > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x - dragFactor, rb.velocity.y);
            }
            if (rb.velocity.x < 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x + dragFactor, rb.velocity.y);
            }
        jumpTimeCounter = jumpTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            isJumping = true;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if(jumpTimeCounter > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space) && isJumping)
        {
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
