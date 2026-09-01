using TMPro;
using UnityEngine;

public class GetRidOfTimerDuringBossWave : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public SpriteRenderer clock;
    public TMP_Text Timer;
    public TMP_Text Timer2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemySpawn.wave[enemySpawn.waveNumber].bossWave == true)
        {
            clock.enabled = false;
            Timer.enabled = false;
            Timer2.enabled = false;
        }
        else
        {
            clock.enabled = true;
            Timer.enabled = true;
            Timer2.enabled = true;
        }
    }
}
