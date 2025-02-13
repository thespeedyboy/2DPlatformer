using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{
    [Header("Horizontal Movment")]
    public float Speed;
    private float horizontalInput;
    [Header("Jumping")]
    public float jumpForce;
    private bool isOnGround = true;
    //Compontents
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Speed * Time.deltaTime * horizontalInput);
        animator.SetFloat("horizontalInput",Mathf.Abs(horizontalInput));
        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isOnGround", isOnGround);
        }
        //Flip the sprite to face forward
        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("isOnGround", isOnGround);
        }
    }

}
