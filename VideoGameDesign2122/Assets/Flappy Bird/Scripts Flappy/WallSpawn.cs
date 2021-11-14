using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    //Get spawnrate variable
    public int secondsBetweenWalls;

    bool spawnNew = true;

    //Array of different walls to spawn
    public GameObject[] walls;

    void Update()
    {
        //If able to spawn a wall (specified below)
        if (spawnNew)
        {
            //Spawn wall
            StartCoroutine(SpawnWall());
        }
    }

    IEnumerator SpawnWall()
    {
        //Stop new spawning
        spawnNew = false;

        //Spawn random wall from array of walls
        Instantiate(walls[Random.Range(0, walls.Length)], transform.position, transform.rotation);

        //Wait for spawnrate seconds specified
        yield return new WaitForSeconds(secondsBetweenWalls);

        //Let spawn a new wall
        spawnNew = true;
    }
}
