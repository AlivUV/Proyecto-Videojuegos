using UnityEngine;

public class Player2Controller : MonoBehaviour
{
  [Header("Movement")]

  public float movementForce = 20f;
  public float jumpForce = 60f;
  public float jumpLimit = -6.5f;
  public float floorLimit = -7f;
  public float rightLimit = 19f;
  public float centerLimit = 0f;

  private Rigidbody2D rb;

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
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
  }

  private void Jump()
  {
    if (Input.GetKey(KeyCode.UpArrow))
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

}
