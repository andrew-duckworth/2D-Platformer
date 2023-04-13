using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
  public Rigidbody2D playerRb;
  public float speed;
  //tracks x (left or right)
  public float input;
  public SpriteRenderer spriteRenderer;
  public float jumpForce;

  public LayerMask groundLayer;
  private bool isGrounded;
  public Transform feetPosition;
  public float groundCheckCircle;

    // Update is called once per frame
    void Update()
    {
      //sets -1 or 1 depending on key press
       input = Input.GetAxisRaw("Horizontal");
       //flips image direction based on this value
        if(input < 0)
        {
          spriteRenderer.flipX = true;
        }
        else if(input > 0)
        {
          spriteRenderer.flipX = false;
        }


      isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

      if(isGrounded == true && Input.GetButton("Jump"))
      {
        playerRb.velocity = Vector2.up * jumpForce;
      }


    }

  void FixedUpdate()
  {
    playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
  }

 
}
