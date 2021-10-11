using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    //Get rigidbody for movement and have a speed variable
    Rigidbody2D rb;
    public float ballSpeed = 100;
    Vector2 direction;

    private void Start()
    {
        //Get the rigidbody on the ball
        rb = GetComponent<Rigidbody2D>();

        //Choose a random direction to go
        direction = new Vector2(Random.Range(1f, 1f), Random.Range(0f, 0f));

        //Move in that direction at Time.deltaTime (Fixed framerate) and multiply by the speed variable
        rb.velocity = direction * ballSpeed * Time.deltaTime;
    }
}
