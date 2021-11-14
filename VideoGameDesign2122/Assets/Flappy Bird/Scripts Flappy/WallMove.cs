using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    Fly flyscript;

    private void Start()
    {
        flyscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Fly>();
    }

    void Update()
    {
        if (!flyscript.crashed)
        {
            transform.Translate(transform.forward * flyscript.forwardSpeed * -0.05f);

            if (transform.position.z <= -60)
            {
                Destroy(gameObject);
            }
        }
    }
}
