using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBounce : MonoBehaviour
{
    //Variables
    [HideInInspector] public Rigidbody2D rb;
    public float ballSpeed;
    public bool start = false;
    bool upspeed = true;

    //Display for scores
    public Text aiText;
    public Text playerText;

    //Scores
    int playerScore = 0;
    int aiScore = 0;

    private void Start()
    {
        //Show default scores
        aiText.text = "0";
        playerText.text = "0";

        //Get the rigidbody
        rb = GetComponent<Rigidbody2D>();
        //Start 3 second countdown for ball
        StartCoroutine(Wait_Seconds());
    }

    private void Update()
    {
        //If either score is equal to 7
        if (playerScore == 7 || aiScore == 7)
        {
            //Go to the next scene
        }

        //Show player and AI's text in game
        playerText.text = playerScore.ToString();
        aiText.text = aiScore.ToString();

        //For testing
        if (rb != null)
        {
            //Debug.Log(rb.velocity.sqrMagnitude);
        }

        //Will be set to false when game starts, and true when the function inside the if statement is running
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
        rb.AddForce(new Vector2(Random.Range(0.1f, -1), Random.Range(-1f, 1)).normalized * ballSpeed);

        //Set start to true so AI starts moving
        start = true;

        //Set upspeed to false so the speeding up starts
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
        rb.AddForce((newpos - curpos).normalized * (ballSpeed/15));

        //Restart this countdown loop
        upspeed = false;
    }

    void Respawn()
    {
        //Disable the ball, bring it to the center, and reenable it
        gameObject.SetActive(false);
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);

        //start to false restarts the ball, upspeed to true makes it so speed can't go up yet
        start = false;
        upspeed = true;

        //Start the 3 second countdown again
        StartCoroutine(Wait_Seconds());
    }

    //If ball collides with anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checking if the ball collides with the invisible barrier around the outside
        if (collision.collider.tag == "outside")
        {
            //If it is on the player's side when it goes out
            if (transform.position.y < 0)
            {
                //AI gets a point, and runs the respawn function
                aiScore += 1;
                Respawn();
            }

            //If on AI's side
            if (transform.position.y > 0)
            {
                //Player gets a point, runs respawn function
                playerScore += 1;
                Respawn();
            }
        }
    }
}
