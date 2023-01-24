using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
  private float points = 0;
  private TextMeshProUGUI label;

  // Start is called before the first frame update
  void Start()
  {
    label = GetComponent<TextMeshProUGUI>();
  }

  private void Update()
  {
    label.text = points.ToString("0");
  }

  public void AddPoints()
  {
    points += 1;
  }

}
