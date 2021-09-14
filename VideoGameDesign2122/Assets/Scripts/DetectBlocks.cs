using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectBlocks : MonoBehaviour
{
    //Set up variable to store the objects material to change the color later
    Material objmat;

    // Start is called before the first frame update
    void Start()
    {
        //Get the objects material
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        objmat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        //The ground tile will check to see if there is a block above it
        if (Physics.Raycast(transform.position, Vector3.up))
        {
            //If block above, change to yellow
            objmat.color = Color.yellow;
        } else
        {
            //If no block above, change back to blue
            objmat.color = Color.blue;
        }
    }
}
