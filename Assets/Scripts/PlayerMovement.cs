using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
  public Rigidbody2D playerRb;
  public float speed;

  //tracks x (left or right)
  public float input;

  //grabs sprite image
  public SpriteRenderer spriteRenderer;
  public float jumpForce;

//ground layer check
  public LayerMask groundLayer;
  private bool isGrounded;

  //feet pos check
  public Transform feetPosition;
  public float groundCheckCircle;

  //checks how long you are in the air, max = jumpTime
  public float jumpTime = 0.35f;
  public float jumpTimeCounter;

  //check if jump has already been initiated to prevent double jump
  private bool isJumping;


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

      if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
      {
        isJumping = true;
        jumpTimeCounter = jumpTime;
        playerRb.velocity = Vector2.up * jumpForce;
      }

      if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
      {
        if(jumpTimeCounter > 0)
        {
          playerRb.velocity = Vector2.up * jumpForce;
          jumpTimeCounter -= Time.deltaTime;
        }
        else
        {
          isJumping = false;
        }

      }

      if(Input.GetKeyUp(KeyCode.UpArrow))
      {
        isJumping = false;
      }

    }

  void FixedUpdate()
  {
    playerRb.velocity = new Vector2 (input * speed, playerRb.velocity.y);
  }

 
}
