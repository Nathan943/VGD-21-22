using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    Rigidbody rb;
    public float flapHeight;
    public float moveSpeed;
    public float forwardSpeed;

    bool startGame = false;

    public int points = 0;
    bool pointsGiven = false;

    [HideInInspector] public bool crashed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(points);
        if (startGame)
        {
            if ((Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) && !crashed)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(Vector3.up * flapHeight);
            }

            if ((Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) && !crashed)
            {
                transform.Translate(transform.right * moveSpeed * 0.001f);
            }

            if ((Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) && !crashed)
            {
                transform.Translate(-transform.right * moveSpeed * 0.001f);
            }
        }

        if (!pointsGiven && startGame)
        {
            pointsGiven = true;
            StartCoroutine(GivePoints());
        }
    }

    IEnumerator Countdown()
    {
        rb.useGravity = false;
        yield return new WaitForSeconds(3);
        startGame = true;
        rb.useGravity = true;
    }

    IEnumerator GivePoints()
    {
        yield return new WaitForSeconds(2f);
        points++;
        pointsGiven = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        crashed = true;

        rb.velocity = Vector3.zero;
    }
}
