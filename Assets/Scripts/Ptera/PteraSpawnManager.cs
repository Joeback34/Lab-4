using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PteraSpawnManager : MonoBehaviour
{
    public GameObject PteraPrefab; // the enemy prefab to spawn
    public float spawnRate; // how often to spawn an enemy
  
    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            

            // spawn the enemy at the calculated position
            Instantiate(PteraPrefab, new Vector3(11f, 3f, 0f), Quaternion.identity);

            // set the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
