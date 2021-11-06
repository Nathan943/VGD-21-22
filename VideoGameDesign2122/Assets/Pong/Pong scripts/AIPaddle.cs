using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    //Get the ball bounce script and the speed the AI rotates at
    public BallBounce bouncescript;
    public float airotSpeed;

    void Update()
    {
        //If the balls x position is greater than paddles position (The random numbers are to make it easier for the player)
        if (bouncescript.start)
        {
            if ((bouncescript.rb.transform.position.x > transform.position.x - 0.2f) || (bouncescript.rb.transform.position.x > transform.position.x + 0.2f))
            {
                //If the ball is near the Ai's side
                if (bouncescript.rb.transform.position.y > -0.75)
                {
                    MovePaddleRight();
                }
            }
            else if (bouncescript.rb.transform.position.y > -0.75)
            {
                MovePaddleLeft();
            }
        }
    }

    void MovePaddleRight()
    {
        //If it isn't across the middle
        if (transform.position.y > 0.46)
        {
            //Rotate right
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, airotSpeed * Time.deltaTime);

            if (transform.position.y <= 0.46)
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.forward, airotSpeed * Time.deltaTime);
            }
        }
    }

    void MovePaddleLeft()
    {
        //If it isn't across the middle
        if (transform.position.y > 0.46)
        {
            //Rotate left
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.forward, airotSpeed * Time.deltaTime);

            if (transform.position.y <= 0.46)
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, airotSpeed * Time.deltaTime);
            }
        }
    }
}
