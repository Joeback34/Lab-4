using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{   
    public float spawnRate;
    private float nextSpawnTime;
    public GameObject CloudPrefab;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {


            // spawn the enemy at the calculated position
            Instantiate(CloudPrefab, new Vector3(11f, 3f, 0f), Quaternion.identity);

            // set the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
