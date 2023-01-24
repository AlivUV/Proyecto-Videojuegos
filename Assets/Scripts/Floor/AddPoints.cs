using UnityEngine;
using TMPro;

public class AddPoints : MonoBehaviour
{
  public Score scoreP1;
  public Score scoreP2;
  public Player1Controller player1;
  public Player2Controller player2;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (!other.collider.CompareTag("Ball"))
    {
      return;
    }

    player1.restoreInitPositions();
    player2.restoreInitPositions();

    if (other.collider.attachedRigidbody.position.x < 0)
    {
      scoreP2.AddPoints();
      player1.Throw();
      player2.BallGrab();
    }
    else
    {
      scoreP1.AddPoints();
      player2.Throw();
      player1.BallGrab();
    }
  }

}
