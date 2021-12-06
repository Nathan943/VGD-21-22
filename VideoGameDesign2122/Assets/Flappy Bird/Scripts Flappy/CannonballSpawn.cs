using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballSpawn : MonoBehaviour
{
    bool canSpawn = false;
    public float seconds = 10;
    public float cannonballTimeDecreaseRate;
    public int cannonSpeed;

    public Rigidbody cannonballClone;
    public Transform player;

    int[] choices = {-30, 30};

    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        canSpawn = false;

        yield return new WaitForSeconds(seconds);
        Rigidbody clone = Instantiate(cannonballClone, new Vector3(choices[Random.Range(0, choices.Length)], Random.Range(20, -20), Random.Range(-10, -20)), transform.rotation);

        clone.transform.LookAt(player);

        clone.AddForce(clone.transform.forward * cannonSpeed);

        seconds = seconds - cannonballTimeDecreaseRate;

        canSpawn = true;
    }
}
