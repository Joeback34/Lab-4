using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // the enemy prefab to spawn
    public float spawnRate; // how often to spawn an enemy
    public float spawnRadius; // how far from the center of the screen to spawn enemies
    public float spawnHeight; // how high above the screen to spawn enemies
    private float nextSpawnTime;
    public List<Enemy> enemies = new List<Enemy>();
    private void Update()
    {

        if (Time.time >= nextSpawnTime)
        {
            // calculate a random spawn position on the left or right side of the screen
            Vector3 spawnPosition = new Vector3(Random.Range(0, 2) == 0 ? -1 : 1, 0, 0);
            spawnPosition *= spawnRadius;
            spawnPosition.y = spawnHeight;

            // spawn the enemy at the calculated position
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            enemies.Add(enemy.GetComponent<Enemy>());

            // set the next spawn time based on the spawn rate
            nextSpawnTime = Time.time + spawnRate;
        }


    }

    public void PauseEnemies()
    {
        foreach(Enemy e in enemies)
        {
            if(e != null)
            {
                e.PauseEnemy();
            }
        }
    }
}