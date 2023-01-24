using UnityEngine;

public class BallLimits : MonoBehaviour
{
  public float rightLimit = 19f;
  public float leftLimit = -19f;

  private Rigidbody2D rb;

  // Start is called before the first frame update
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  private void Update()
  {
    Bounce();
  }

  private void Bounce()
  {
    if (rb.position.x < leftLimit)
    {
      rb.velocity = new Vector2(Mathf.Abs(rb.velocity.x), rb.velocity.y);
    }
    else if (rb.position.x > rightLimit)
    {
      rb.velocity = new Vector2(-Mathf.Abs(rb.velocity.x), rb.velocity.y);
    }
  }

}
