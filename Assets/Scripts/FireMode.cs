using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMode : MonoBehaviour
{
    public float timeTillFire;
    public float fireModeTime;
    public bool isFireMode;
    [SerializeField]
    private PlayerController player;

    public EnemySpawn enemySpawn;
    public int activatorCounter;
    
    public int liveActivators;
    [SerializeField] private FireActivator fireActivator;
    public int requiredActivators;





    void Start()
    {
        isFireMode = false;
        requiredActivators = 3;


    //fireCollider.enabled = true;
    /* timeTillFire;
     fireModeTime;*/

    //StartCoroutine(EnableFireMode());
}

    // Update is called once per frame
    void Update()
    {
        if (activatorCounter >= requiredActivators)
        {
            //Enable fire mode
            StartCoroutine(DisableFireMode());
            isFireMode = true;
            

            //enemySpawn.timeStep = enemySpawn.timeStep - 0.1f;
            enemySpawn.waveNumber = enemySpawn.waveNumber + 1;
            player.lifeCount = player.lifeCount + 1;
            activatorCounter = 0;
            

        }
        if (liveActivators == 0 )
        {
            for (int i = 0; i < requiredActivators; i++)
            {
                Vector2 activatorSpawnPosition = new Vector2(Random.Range(enemySpawn.xMin, enemySpawn.xMax), Random.Range(enemySpawn.yMin, enemySpawn.yMax));
                // Debug.Log(activatorSpawnPosition);
                Instantiate(fireActivator, activatorSpawnPosition, Quaternion.identity);
                liveActivators++;
            }
            
            
        }

    }
    IEnumerator EnableFireMode()
    {
        yield return new WaitForSeconds(timeTillFire);
        StartCoroutine(DisableFireMode());
        //fireCollider.enabled = true;
       
        isFireMode = true;
        
        //enemySpawn.timeStep = enemySpawn.timeStep - 0.1f;
        enemySpawn.waveNumber = enemySpawn.waveNumber + 1;
        player.lifeCount = player.lifeCount + 1;
        



    }
    IEnumerator DisableFireMode()
    {
        yield return new WaitForSeconds(fireModeTime);
        // StartCoroutine(EnableFireMode());
        //fireCollider.enabled = false;
        StartCoroutine(ActivatorWaitTime());
        isFireMode = false;


    }
    IEnumerator ActivatorWaitTime()
    {
        yield return new WaitForSeconds(3f);
        liveActivators = 0;
    }

}
