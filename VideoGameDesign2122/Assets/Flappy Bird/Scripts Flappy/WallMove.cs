using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    //Variable for fly script
    Fly flyscript;

    private void Start()
    {
        //Get the fly script
        flyscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Fly>();
    }

    void Update()
    {
        //If you haven't crashed
        if (!flyscript.crashed)
        {
            //Move itself (the wall)
            transform.Translate(transform.forward * flyscript.forwardSpeed * -0.05f);

            //If past the player's view
            if (transform.position.z <= -60)
            {
                //Delete itself for performance
                Destroy(gameObject);
            }
        }
    }
}
