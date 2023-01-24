using UnityEngine;
using System.Collections.Generic;

public class Player1Controller : PlayerController
{
  public float leftLimit = -19f;

  // Start is called before the first frame update
  protected override void Start()
  {
    Initialize();

    handIndex = 6;

    BallGrab();
  }

  protected override void Movement()
  {
    if (Input.GetKey(KeyCode.A))
    {
      rb.velocity = new Vector2(-movementForce, rb.velocity.y);
    }
    if (Input.GetKey(KeyCode.D))
    {
      rb.velocity = new Vector2(movementForce, rb.velocity.y);
    }

    if (Input.GetKey(KeyCode.S))
    {
      rb.velocity = new Vector2(rb.velocity.x, -movementForce);
    }

    if (Input.GetKey(KeyCode.R))
    {
      Throw();
    }
  }

  protected override void Jump()
  {
    if (Input.GetKey(KeyCode.W))
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

    if (rb.position.x > centerLimit)
    {
      rb.velocity = new Vector2(rb.velocity.x + (-movementForce * rb.position.x), rb.velocity.y);
      return;
    }

    if (rb.position.x < leftLimit)
    {
      rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), rb.velocity.y);
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

    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(hand.velocity.x + 5, hand.velocity.y + 5);

    grabbing = false;
  }

}
