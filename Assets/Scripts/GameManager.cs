using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int MaxAllowedEnemies = 20;
    int currentNumberOfEnemies = 0;
   
    public bool CanSpawnEnemy()
    {
        if (currentNumberOfEnemies < MaxAllowedEnemies)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RecordEnemySpawned()
    {
        currentNumberOfEnemies++;
    }
    public void RecordEnemyDestroyed()
    {
        currentNumberOfEnemies--;
    }
}
