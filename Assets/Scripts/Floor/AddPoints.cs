using UnityEngine;
using TMPro;

public class AddPoints : MonoBehaviour
{
  [SerializeField] public Score scoreP1;
  [SerializeField] public Score scoreP2;

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (!other.collider.CompareTag("Ball"))
    {
      return;
    }

    if (other.collider.attachedRigidbody.position.x < 0)
    {
      scoreP1.AddPoints();
    }
    else
    {
      scoreP2.AddPoints();
    }
  }

}
