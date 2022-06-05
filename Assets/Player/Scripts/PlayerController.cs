using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalMove = 0f;
    private bool jump = false;
    public Transform checkGround;
    private bool isGround;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        if (Input.GetKey(KeyCode.W) && isGround)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {

        UpdateGround();
        PlayerMove();
        
    }
    void UpdateGround()
    {
        isGround = Physics2D.OverlapCircle(checkGround.position, 0.1f, groundLayer);
        if (isGround)
            animator.SetBool("isGround", true);
    }

    void PlayerMove()
    {
        if(horizontalMove > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            Vector2 newVelocity = rb.velocity;
            newVelocity.x = horizontalMove;
            rb.velocity = newVelocity;

            if (isGround && !jump)
            {
                animator.SetBool("isWalk", true);
            }
            
        }
        if(horizontalMove < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

            Vector2 newVelocity = rb.velocity;
            newVelocity.x = horizontalMove;
            rb.velocity = newVelocity;
            if (isGround && !jump)
            {
                animator.SetBool("isWalk", true);
            }
        }
        if(horizontalMove == 0 && isGround)
        {
            animator.SetBool("isWalk", false);
        }
        if (jump)
        {
            animator.SetTrigger("isJump");
            animator.SetBool("isGround", false);
            rb.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }
}
