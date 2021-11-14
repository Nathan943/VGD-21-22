using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public int secondsBetweenWalls;

    bool spawnNew = true;

    public GameObject[] walls;

    // Update is called once per frame
    void Update()
    {
        if (spawnNew)
        {
            StartCoroutine(SpawnWall());
        }
    }

    IEnumerator SpawnWall()
    {
        spawnNew = false;

        Instantiate(walls[Random.Range(0, walls.Length)], transform.position, transform.rotation);

        yield return new WaitForSeconds(secondsBetweenWalls);

        spawnNew = true;
    }
}
