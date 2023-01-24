using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehavior : MonoBehaviour
{
    public float Speed = 1f;
    public float torqueSpeed = 500f;
    public GameObject objective;
    public float dx = 0f;
    public float dy = 0f;

    public float duration = 0f;

    private Rigidbody2D _rigidbody;
    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void Update()
    {
        setVelocity();
        _rigidbody.MovePosition(new Vector2(transform.position.x + dx, transform.position.y + dy));
        duration += Time.deltaTime;
        if (duration >= 20) {
            Destroy(gameObject);
        }
    }
    
    

    private void OnCollisionEnter2D(Collision2D other) {
        _rigidbody.AddTorque(torqueSpeed);
    }
    
    private void setVelocity()
    {
        float vx = objective.transform.position.x - transform.position.x;
        float vy = objective.transform.position.y - transform.position.y;
        float magnitude = Mathf.Sqrt(Mathf.Pow(vx, 2f) + Mathf.Pow(vy, 2f));
        dx = vx / magnitude * Speed * Time.fixedDeltaTime;
        dy = vy / magnitude * Speed * Time.fixedDeltaTime;
    }

    

    
}
