using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool die = false;

    public Text pointsText;

    public AudioClip flap;
    public AudioClip crash;
    AudioSource audio;
    

    [HideInInspector] public bool crashed = false;

    private void Start()
    {
        //Get rigidbody and start game countdown
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Countdown());
        audio = GetComponentInChildren<AudioSource>();
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
                audio.clip = flap;
                audio.Play();

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
        yield return new WaitForSeconds(1.5f);
        startGame = true;
        rb.useGravity = true;
        yield return new WaitForSeconds(4.5f);
        startPoints = true;
        points++;

    }

    //Still working on
    IEnumerator GivePoints()
    {
        yield return new WaitForSeconds(3.3f);
        if (!die)
        {
            points++;
            pointsGiven = false;
        }
    }

    //Check for crashing with wall
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(ReloadScene());
    }

    //Check for crashing with boundaries
    private void OnTriggerEnter(Collider other)
    {
        rb.velocity = Vector3.zero;

        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        if (crashed == false)
        {
            audio.clip = crash;
            audio.Play();

            crashed = true;
            die = true;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
