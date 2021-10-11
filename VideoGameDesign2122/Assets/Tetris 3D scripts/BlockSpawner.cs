using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    //Set up variables for everything in the script
    public GameObject[] blocks;

    //Define width, height, and length for the arena
    public int width = 140;
    public int height = 800;
    public int length = 140;

    //Define blocks
    GameObject block;
    [HideInInspector] public GameObject cloneobj;

    //Define size of the playing field
    Transform[,,] grid;

    //Define variables for timing of falling
    public float fallspeed;
    public float previousTime;

    public Transform placeholderObject;

    private void Start()
    {
        grid = new Transform[width, height, length];


        //Chooses a random block from the list of blocks in blocks[]
        block = blocks[Random.Range(0, blocks.Length)];
        //Creates a clone of the random block at the top of the game
        cloneobj = Instantiate(block, new Vector3(2.5f, 9.5f, 2.5f), Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        RotateBlocks();
        MoveBlocks();

        //Falls down after the time that is specified in fallspeed. If down arrow is pressed, fall faster
        if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallspeed / 10 : fallspeed))
        {
            cloneobj.transform.position += new Vector3(0, -1, 0);
            previousTime = Time.time;

            if (AllowedToMove())
            {
                //Add coordinates to grid for "collisions" with other blocks
                AddCoordsToGrid();

                //Spawn new block in
                block = blocks[Random.Range(0, blocks.Length)];
                cloneobj = Instantiate(block, new Vector3(2.5f, 9.5f, 2.5f), Quaternion.identity);
            }
        }
    }

    void AddCoordsToGrid()
    {
        foreach (Transform children in cloneobj.transform)
        {
            int roundedX = Mathf.RoundToInt(children.transform.TransformPoint(Vector3.zero).x);
            int roundedY = Mathf.RoundToInt(children.transform.TransformPoint(Vector3.zero).y);
            int roundedZ = Mathf.RoundToInt(children.transform.TransformPoint(Vector3.zero).z);
            grid[roundedX, roundedY, roundedZ] = children;
        }
    }

    void RotateBlocks()
    {
        //Rotate
        if (Input.GetKeyDown("e"))
        {
            cloneobj.transform.eulerAngles -= new Vector3(0, 0, 90);
            if (!AllowedToMove())
            {
                Debug.Log("Back");
                cloneobj.transform.eulerAngles -= new Vector3(0, 0, -90);
            }
        }
    }

    void MoveBlocks()
    {

    }

    bool AllowedToMove()
    {
        //Loop over for each tiny cube in each block
        foreach (Transform children in cloneobj.transform)
        {
            //Get the coordinates of each tiny cube
            int roundedX = Mathf.RoundToInt(children.transform.position.x);
            int roundedY = Mathf.RoundToInt(children.transform.position.y);
            int roundedZ = Mathf.RoundToInt(children.transform.position.z);

            //Check to see if any tiny cubes are out of the playing field boundaries
            if (/*roundedX > width / 2 || roundedX < width / -2 ||*/ roundedY < 1 /*|| roundedZ > length / 2 || roundedZ < length / -2*/)
            {
                //If so, return false (can't move that way)
                return false;
            }

            //Also check to see if the position the block is going to move to is taken up by another block
            if (grid[roundedX, roundedY, roundedZ] != null)
            {
                return false;
            }
        }

        //Otherwise, return true (can move that way)
        return true;
    }
}
