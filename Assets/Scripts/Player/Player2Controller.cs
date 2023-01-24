using UnityEngine;
using System.Collections.Generic;

public class Player2Controller : PlayerController
{

  public float rightLimit = 19f;

  protected override void Start()
  {
    Initialize();

    handIndex = 4;
  }

  protected override void Movement()
  {
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      rb.velocity = new Vector2(-movementForce, rb.velocity.y);
    }
    if (Input.GetKey(KeyCode.RightArrow))
    {
      rb.velocity = new Vector2(movementForce, rb.velocity.y);
    }

    if (Input.GetKey(KeyCode.DownArrow))
    {
      rb.velocity = new Vector2(rb.velocity.x, -movementForce);
    }

    if (Input.GetKey(KeyCode.Space))
    {
      Throw();
    }
  }

  protected override void Jump()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      if (CanJump())
      {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      }
    }
  }

  protected override void Limits()
  {
    if (rb.position.y < floorLimit)
    {
      rb.velocity = new Vector2(rb.velocity.x, (-movementForce * (rb.position.y - floorLimit + 0.1f)));
    }

    if (rb.position.x < centerLimit)
    {
      rb.velocity = new Vector2(rb.velocity.x + (-movementForce * rb.position.x), rb.velocity.y);
      return;
    }

    if (rb.position.x > rightLimit)
    {
      rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), rb.velocity.y);
      return;
    }
  }

  public override void Throw()
  {
    if (!grabbing)
    {
      return;
    }

    Destroy(ball.GetComponent<FixedJoint2D>());

    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(hand.velocity.x - 5, hand.velocity.y + 5);

    grabbing = false;
  }

}
