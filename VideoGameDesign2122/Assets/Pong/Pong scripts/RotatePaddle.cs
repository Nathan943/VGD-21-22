using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePaddle : MonoBehaviour
{
    //Speed to rotate at
    public int rotateSpeed;

    void Update()
    {
        //If d or right arrow pressed, rotate to the right
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.forward, rotateSpeed * Time.deltaTime);

            if (transform.position.y >= -0.46)
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, rotateSpeed * Time.deltaTime);
            }
        }

        //If a or left arrow pressed, rotate to the left
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, rotateSpeed * Time.deltaTime);

            if (transform.position.y >= -0.46)
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.forward, rotateSpeed * Time.deltaTime);
            }
        }
    }
}
