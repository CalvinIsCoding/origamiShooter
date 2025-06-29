using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameStatsScript", menuName = "Scriptable Objects/New Game Stats Script")]
public class GameStatsScript : ScriptableObject
{
    public int enemiesKilledThisWave;
    public int totalEnemiesKilled;
    public int enemiesSpawnedThisWave;
    public int totalEnemiesSpawned;
    public int totalMoneyEarned;
    public int wavesSurvived;
    public int[] enemiesKilledEachWave = new int[100];

    public void ResetEnemyCounters()
    {
        enemiesKilledThisWave = 0;
        totalEnemiesKilled = 0;
        totalEnemiesSpawned = 0;
        enemiesSpawnedThisWave = 0;
        totalMoneyEarned = 0;
        wavesSurvived = 0;
        for (int i = 0; i < 99; i++)
        {
            enemiesKilledEachWave[i] = 0;
        }
        
    }
    public void EndOfWave(int waveNumber)
    {
        enemiesKilledEachWave[waveNumber] = enemiesKilledThisWave;
        enemiesKilledThisWave = 0;
        enemiesSpawnedThisWave = 0;
    }

}
