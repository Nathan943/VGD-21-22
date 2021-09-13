using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    //Set up variables for the list of block objects, the selected block to spawn, the boolean for checking if a block can spawn, and the speed the blocks fall at
    public GameObject[] blocks;
    GameObject block;
    bool canSpawn = true;
    public float fallspeed = 1.5f;

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

        //This moves the clone block down the game until it reaches the bottom
        for (float i = 10.5f; i > 0.5f; i--)
        {
            cloneobj.transform.Translate(transform.position.x, transform.position.y - 1f, transform.position.z);
            yield return new WaitForSeconds(fallspeed);
        }

        //Allow another block to spawn
        canSpawn = true;
    }
}
