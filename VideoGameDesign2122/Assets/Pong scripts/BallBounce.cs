using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    //Variables for the rigidbody, ball speed, 3 second delay at the start, and when to up the speed of the ball
    [HideInInspector] public Rigidbody2D rb;
    public float ballSpeed;
    public bool start = false;
    bool upspeed = true;

    private void Start()
    {
        //Get the rigidbody
        rb = GetComponent<Rigidbody2D>();
        //Start 3 second countdown for ball
        StartCoroutine(Wait_Seconds());
    }

    private void Update()
    {
        //For testing
        if (rb != null)
        {
            Debug.Log(rb.velocity.sqrMagnitude);
        }

        //After it is set to false
        if (upspeed == false)
        {
            //Start speed up countdown
            StartCoroutine(SpeedUp());
        }
    }

    IEnumerator Wait_Seconds()
    {
        //Wait 3 secs
        yield return new WaitForSeconds(3);

        //Add force to move the ball
        rb.AddForce(new Vector2(Random.Range(0.1f, -1), Random.Range(-1f, 1)).normalized * ballSpeed * Time.deltaTime);

        //Set start to true so AI starts moving
        start = true;

        //Set upspeed to false so the speecing up starts
        upspeed = false;
    }

    IEnumerator SpeedUp()
    {
        //Stop countdown until this loop is finished
        upspeed = true;

        //Wait for 5 secss
        yield return new WaitForSeconds(5f);

        //Get the direction that the ball is travelling by taking two points at different times and connecting them
        Vector2 curpos = transform.position;
        yield return new WaitForSeconds(0.1f);
        Vector2 newpos = transform.position;

        //Add a bit more force in the direction of movement to speed up
        rb.AddForce((newpos - curpos).normalized * (ballSpeed/25) * Time.deltaTime);

        //Restart this countdown loop
        upspeed = false;
    }
}
