using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public Fly flyscript;

    private void Start()
    {
        flyscript = GameObject.FindGameObjectWithTag("Player").GetComponent<Fly>();
    }

    void Update()
    {
        transform.Translate(transform.forward * flyscript.forwardSpeed * -0.1f);
    }
}
