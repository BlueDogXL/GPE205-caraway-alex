using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject objectToSpawn;
    public float timeBetweenSpawns;
    public GameObject spawnedObject;
    public bool isSpawnAtStart;
    private float spawnCountdown;
    void Start()
    {
        if (isSpawnAtStart == true)
        {
            spawnCountdown = 0;
        }
        else
        {
            spawnCountdown = timeBetweenSpawns;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedObject != null)
        {
            // something exists, don't do anything
        }
        else
        {
            spawnCountdown -= Time.deltaTime;
            if (spawnCountdown <= 0)
            {
                spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
                spawnCountdown = timeBetweenSpawns;
            }
        }
    }
}
