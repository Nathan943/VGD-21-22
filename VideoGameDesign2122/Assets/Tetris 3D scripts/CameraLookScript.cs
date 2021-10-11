using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookScript : MonoBehaviour
{
    //Setting up variables for Camera, point camera rotates around, and the speed it rotates
    private Camera maincam;
    public Transform target;
    public float speed = 5;

    // Setting variable maincam to the game camera
    void Start()
    {
        maincam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera look at target
        transform.LookAt(target);

        //Check for arrow key or WASD inputs
        //Move right or left based on current rotation, a set framerate (deltaTime), and the speed. It will rotate in a circle because it is always looking at the center and moving right or left
        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
