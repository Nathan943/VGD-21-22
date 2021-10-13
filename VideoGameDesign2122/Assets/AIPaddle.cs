using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    // Start is called before the first frame update
    public BallBounce bouncescript;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.up);
        RaycastHit hit;


        if (bouncescript.cloneobj != null) 
        {
            if (bouncescript.cloneobj.transform.position.x > transform.position.x)
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.back, 200 * Time.deltaTime);
            }

            if (bouncescript.cloneobj.transform.position.x < transform.position.x)
            {
                transform.RotateAround(new Vector3(0f, 0f, 0f), Vector3.forward, 200 * Time.deltaTime);
            }
        }
    }
}
