using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public SawBehavior saw;
    public Transform sawSpawnPoint;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        SawBehavior newSaw = Instantiate(saw, sawSpawnPoint.position, transform.rotation) as SawBehavior;
        newSaw.objective = player;
    }
}
