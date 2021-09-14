using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    //Set up variables for the list of block objects, the selected block to spawn, the boolean for checking if a block can spawn, and the speed the blocks fall at
    public GameObject[] blocks;
    GameObject block;
    bool canSpawn = true;
    public float fallspeed;

    //Set up the variable that stores the information of what the raycast hit (More below)
    RaycastHit hitInfo;

    // Update is called once per frame
    void Update()
    {
        //Checking if the block can spawn and if so, run the function below. A Coroutine/IEnumerator is just a special function that allows to have time delays in it (Ln 34)
        if (canSpawn)
        {
            StartCoroutine(SpawnBlocks());
        }
    }

    IEnumerator SpawnBlocks()
    {
        //Sets spawning to false so no other blocks spawn until we want
        canSpawn = false;

        //Chooses a random block from the list of blocks in blocks[]
        block = blocks[Random.Range(0, blocks.Length)];
        //Creates a clone of the random block at the top of the game
        GameObject cloneobj = Instantiate(block, new Vector3(0f, 10.5f, 0f), Quaternion.identity);

        //This uses a feature called a Raycast, which is an invisible line going in a certain direction that can detect if it collides with something
        //It is checking and moving down if there isn't an object below it, otherwise it stops moving and continues on
        while (!Physics.Raycast(cloneobj.transform.position, new Vector3(0f, -1f, 0f), out hitInfo, 1f))
        {
            //Move block down by 1 unit and wait to fall again
            cloneobj.transform.Translate(transform.position.x, transform.position.y - 1f, transform.position.z);

            yield return new WaitForSeconds(fallspeed);
        }

        //Allow another block to spawn
        canSpawn = true;
    }
}
