using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fly : MonoBehaviour
{
    //All of the variables and getting physics rigidbody
    Rigidbody rb;
    public float flapHeight;
    public float moveSpeed;
    public float forwardSpeed;
    public float dizzinessModifier;

    bool startGame = false;
    bool startPoints = false;

    public int points = 0;
    bool pointsGiven = false;

    public Text pointsText;
    

    [HideInInspector] public bool crashed = false;

    private void Start()
    {
        //Get rigidbody and start game countdown
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Countdown());
    }

    void Update()
    {
        pointsText.text = points.ToString();

        //Movement for the player
        if (startGame)
        {
            //Check if keys are pressed and if you haven't crashed
            if ((Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) && !crashed)
            {
                //Stop falling
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

                //Flap up
                rb.AddForce(Vector3.up * flapHeight);
            }

            if ((Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) && !crashed)
            {
                //Move right
                transform.Translate(transform.right * moveSpeed * 0.001f);
            }

            if ((Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) && !crashed)
            {
                //Move left
                transform.Translate(-transform.right * moveSpeed * 0.001f);
            }
        }

        //Points system
        if (!pointsGiven && startPoints)
        {
            pointsGiven = true;
            StartCoroutine(GivePoints());
        }

        //Check if the player isn't falling too fast because if they are, the camera will rotate 360 degrees.
        if (rb.velocity.y > -50 && rb.velocity.y < 50)
        {
            //Rotate based on how fast you are falling or climbing (getting y velocity)
            transform.Rotate(new Vector3(-rb.velocity.y * dizzinessModifier * 0.005f, 0, 0));
        }
    }

    //Countdown for the start of the game
    IEnumerator Countdown()
    {
        rb.useGravity = false;
        yield return new WaitForSeconds(3);
        startGame = true;
        rb.useGravity = true;
        yield return new WaitForSeconds(2.5f);
        startPoints = true;
        points++;

    }

    //Still working on
    IEnumerator GivePoints()
    {
        yield return new WaitForSeconds(4f);
        points++;
        pointsGiven = false;
    }

    //Check for crashing with wall
    private void OnCollisionEnter(Collision collision)
    {
        //If so, set crashed to true which makes other parts do stuff
        crashed = true;
        pointsGiven = true;

        //Stop player from moving
        rb.velocity = Vector3.zero;
        //rb.useGravity = false;
    }
}
