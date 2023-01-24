using UnityEngine;
using System.Collections.Generic;

public abstract class PlayerController : MonoBehaviour
{
  [Header("Movement")]

  public float movementForce = 20f;
  public float jumpForce = 60f;
  public float jumpLimit = -6.5f;
  public float floorLimit = -7f;
  public float centerLimit = 0f;
  public Rigidbody2D hand;
  public GameObject ball;

  protected int handIndex;
  protected bool grabbing;
  protected List<Vector2> initPositions;
  protected List<Quaternion> initRotations;
  protected Rigidbody2D rb;

  // Start is called before the first frame update
  protected abstract void Start();

  protected void Initialize()
  {
    initPositions = new List<Vector2>();
    initRotations = new List<Quaternion>();

    rb = GetComponent<Rigidbody2D>();

    savePositions();
  }

  // Update is called once per frame
  protected void Update()
  {
    Movement();
    Limits();
    Jump();
  }

  protected abstract void Movement();

  protected abstract void Jump();

  protected bool CanJump()
  {
    return rb.position.y <= jumpLimit;
  }

  protected abstract void Limits();

  public void BallGrab()
  {
    var handPos = initPositions[handIndex];
    ball.GetComponent<Rigidbody2D>().position = new Vector2(handPos.x + ((handIndex - 5) * 1f), handPos.y);
    ball.AddComponent<FixedJoint2D>().connectedBody = hand;

    grabbing = true;
  }

  public abstract void Throw();

  protected void savePositions()
  {
    foreach (Transform child in transform.parent.transform)
    {
      initPositions.Add(child.position);
      initRotations.Add(child.rotation);
    }
  }

  public void restoreInitPositions()
  {
    int i = 0;
    foreach (Transform child in transform.parent.transform)
    {
      child.position = initPositions[i];
      child.rotation = initRotations[i];
      i += 1;
    }
  }

}
