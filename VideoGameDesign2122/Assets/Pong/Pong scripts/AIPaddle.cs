using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    //Get the ball bounce script and the speed the AI rotates at
    public BallBounce bouncescript;
    public float airotSpeed;
    public float ballTrackingHeight;
    public float difficulty;

    void Update()
    {
        if (bouncescript.start)
        {
            //If the balls x position is greater than paddles position (The difficulty variable can be adjusted in Inspector)
            if (bouncescript.rb.transform.position.x > transform.position.x + difficulty || bouncescript.rb.transform.position.x > transform.position.x - difficulty)
            {
                //If the ball is close to AI's side
                if (bouncescript.rb.transform.position.y > ballTrackingHeight)
                {
                    MovePaddleRight();
                }
            }
            //Otherwise ball is on left side of AI
            else if (bouncescript.rb.transform.position.y > ballTrackingHeight)
            {
                MovePaddleLeft();
            }
        }
    }

    void MovePaddleRight()
    {
        //If it isn't across the middle line
        if (transform.position.y > 0.46)
        {
            //Rotate right
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, airotSpeed * Time.deltaTime);

            //If paddle is past middle line
            if (transform.position.y <= 0.46)
            {
                //Counterrotate
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

            //If paddle is past middle line
            if (transform.position.y <= 0.46)
            {
                //Counterrotate
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, airotSpeed * Time.deltaTime);
            }
        }
    }
}
