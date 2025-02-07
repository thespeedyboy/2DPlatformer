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
    private Rigidbody2D rb;
    private bool isOnGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }
    void Update()
    {
        //Horizontal Movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Speed * Time.deltaTime * horizontalInput);
        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

}
