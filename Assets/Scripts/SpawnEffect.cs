using UnityEngine;

public class SpawnEffect : MonoBehaviour
{

    public EnemySpawnSounds enemySpawnSounds;
    void Start()
    {
        enemySpawnSounds = FindAnyObjectByType<EnemySpawnSounds>();
        Destroy(this.gameObject,1f);
        enemySpawnSounds.spawnerSoundsActiveNumber++;
    }

    
   
}
