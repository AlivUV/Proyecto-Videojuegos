using UnityEngine;

public class Player1Controller : MonoBehaviour
{
  [Header("Movement")]

  public float movementForce = 20f;
  public float jumpForce = 60f;
  public float jumpLimit = -6.5f;
  public float floorLimit = -7f;
  public float leftLimit = -19f;
  public float centerLimit = 0f;

  public Rigidbody2D hand;
  public GameObject ball;

  private Rigidbody2D rb;

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();

    ball.GetComponent<Rigidbody2D>().position = new Vector2(hand.position.x, hand.position.y - 0.5f);
    ball.AddComponent<FixedJoint2D>().connectedBody = hand;
  }

  // Update is called once per frame
  private void Update()
  {
    Movement();
    Limits();
    Jump();
  }

  private void Movement()
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

  private void Jump()
  {
    if (Input.GetKey(KeyCode.W))
    {
      if (CanJump())
      {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      }
    }
  }

  private bool CanJump()
  {
    return rb.position.y <= jumpLimit;
  }

  private void Limits()
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

  private void Throw()
  {
    Destroy(ball.GetComponent<FixedJoint2D>());

    ball.GetComponent<Rigidbody2D>().velocity = new Vector2(hand.velocity.x + 5, hand.velocity.y + 5);
  }

}
