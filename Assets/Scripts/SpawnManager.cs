using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // the enemy prefab to spawn
    public float spawnRate; // how often to spawn an enemy
    public float spawnRadius; // how far from the center of the screen to spawn enemies
    public float spawnHeight; // how high above the screen to spawn enemies

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // calculate a random spawn position on the left or right side of the screen
            Vector3 spawnPosition = new Vector3(Random.Range(0, 2) == 0 ? -1 : 1, 0, 0);
            spawnPosition *= spawnRadius;
            spawnPosition.y = spawnHeight;

            // spawn the enemy at the calculated position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // set the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + spawnRate;
        }
    }
}
