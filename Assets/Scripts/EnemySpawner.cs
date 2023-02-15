using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    GameManager gameManager;

    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;

    public float spawnTime = 2;

    private void Start()
    {
       GameObject go = GameObject.FindGameObjectWithTag("GameController");
       gameManager = go.GetComponent<GameManager>();

        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime);

    }
    void SpawnEnemy()
    {
        bool allowEnemySpawn = gameManager.CanSpawnEnemy();
        if (allowEnemySpawn == true)
        {
            int randomNo = Random.Range(1, 10);
            if ((randomNo % 2) == 1)
            {
                GameObject Enemy = Instantiate(Enemy2Prefab, transform.position, Quaternion.identity);
                gameManager.RecordEnemySpawned();
            }
            else
            {
                GameObject Enemy = Instantiate(Enemy1Prefab, transform.position, Quaternion.identity);
                gameManager.RecordEnemySpawned();
            }
        }
    }
}
