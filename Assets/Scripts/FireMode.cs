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

    public float moneyMultiplierTimer;
    public float moneyMultiplierTimeElapsed;
    public float activatorWaitTime;
    public bool activatorsSpawned;
    public float moneyMultiplier;
    public MoneyMultiplierBar moneyMultiplierBar;
    public float lastMoneyMultiplier;

    public PlayerInventory playerInventory;
    public GameStatsScript gameStats;

    private bool isSpecialWave;

    void Start()
    {
        moneyMultiplier = 0;
        activatorWaitTime = 3f;
        moneyMultiplierTimer = 10f;
        moneyMultiplierTimeElapsed = 0f;
        isFireMode = false;
        requiredActivators = 3;
        //Live activators is set to 3 here so that they don't spawn right away on the first wave. if live activators was 0 the fire activator switches would spawn immediately upon game load.
        liveActivators = 3;
        activatorsSpawned = false;
        StartCoroutine(DelayActivatorSpawn());
        moneyMultiplierBar.SetMaxMoneyMultiplier(10f);
        
        lastMoneyMultiplier = 0;
        isSpecialWave = false;
        gameStats.ResetEnemyCounters();

    //fireCollider.enabled = true;
        /* timeTillFire;
         fireModeTime;*/

        //StartCoroutine(EnableFireMode());
    }

    // Update is called once per frame
    void Update()
    {

        SetMoneyMultiplier();  
       
    }
    void FixedUpdate()
    {
        isSpecialWave = enemySpawn.wave[enemySpawn.waveNumber].specialWave;
        if (isSpecialWave == true)
        {
            isFireMode = true;
        }
        
        if (activatorCounter >= requiredActivators && isSpecialWave == false)
        {
            
            StartFireAndEndWave();

        }
        if (liveActivators == 0 && isSpecialWave == false)
        {
            SpawnFireActivators();
        }

    }
   /* IEnumerator EnableFireMode()
    {
        yield return new WaitForSeconds(timeTillFire);
        StartCoroutine(DisableFireMode());
        //fireCollider.enabled = true;
       
        isFireMode = true;
        
        //enemySpawn.timeStep = enemySpawn.timeStep - 0.1f;
        enemySpawn.waveNumber = enemySpawn.waveNumber + 1;
        player.lifeCount = player.lifeCount + 1;
        



    }
   */
    IEnumerator DisableFireMode()
    {
        yield return new WaitForSeconds(fireModeTime);
        // StartCoroutine(EnableFireMode());
        //fireCollider.enabled = false;
        StartCoroutine(DelayActivatorSpawn());
        isFireMode = false;
        playerInventory.coins = playerInventory.coins + (int)(playerInventory.coinsBeforeMultiplier * playerInventory.multiplier);
        gameStats.totalMoneyEarned = gameStats.totalMoneyEarned + (int)(playerInventory.coinsBeforeMultiplier * playerInventory.multiplier);
        gameStats.EndOfWave(enemySpawn.waveNumber);
        enemySpawn.waveNumber = enemySpawn.waveNumber + 1;
        gameStats.wavesSurvived++;

    }
    IEnumerator DelayActivatorSpawn()
    {
        yield return new WaitForSeconds(activatorWaitTime);
        liveActivators = 0;
    }
    void StartFireAndEndWave()
    {
        StartCoroutine(DisableFireMode());
        isFireMode = true;


        //enemySpawn.timeStep = enemySpawn.timeStep - 0.1f;
        
        player.lifeCount = player.lifeCount + 1;
        activatorCounter = 0;
        //playerInventory.coins = playerInventory.coins + (int)(playerInventory.coinsBeforeMultiplier * playerInventory.multiplier);
        playerInventory.coinsBeforeMultiplier = 0;
        activatorsSpawned = false;
    }
    void SetMoneyMultiplier()
    {
        if (moneyMultiplierTimeElapsed <= moneyMultiplierTimer && activatorsSpawned == true && isFireMode == false)
        {

            moneyMultiplierTimeElapsed = moneyMultiplierTimeElapsed + Time.deltaTime;
            moneyMultiplier = Mathf.Pow((moneyMultiplierTimer - moneyMultiplierTimeElapsed), 1f) / (moneyMultiplierTimer /10f);
            moneyMultiplierBar.SetMoneyMultiplierBar(moneyMultiplier,isFireMode);
        }
        else if (isFireMode == true)
        {
            moneyMultiplierBar.SetMoneyMultiplierBar(moneyMultiplier,isFireMode);
            playerInventory.multiplier = moneyMultiplier;
            moneyMultiplierTimeElapsed = 0f;

        }
    }
    void SpawnFireActivators()
    {
        Vector2[] activatorSpawnPositions = new Vector2[3];


        for (int i = 0; i < requiredActivators; i++)
        {
            activatorSpawnPositions[i] = new Vector2(Random.Range(enemySpawn.xMin, enemySpawn.xMax), Random.Range(enemySpawn.yMin, enemySpawn.yMax));

            if (i > 0 && (Mathf.Abs(activatorSpawnPositions[i].x - activatorSpawnPositions[i - 1].x) < 0.2 || Mathf.Abs(activatorSpawnPositions[i].y - activatorSpawnPositions[i - 1].y) < 0.1))
            {
                activatorSpawnPositions[i].x = activatorSpawnPositions[i-1].x * -1;
                activatorSpawnPositions[i].y = activatorSpawnPositions[i-1].y * -1;
            }
            
            liveActivators++;
        }
        for (int i = 0; i < requiredActivators; i++)
        {
            Instantiate(fireActivator, activatorSpawnPositions[i], Quaternion.identity);
        }


        activatorsSpawned = true;

    }

    //zones... in an effort to ensure that the fire activators are spaced out... I think it's too complicated.
   /*
    void generateZones(float xMin, float xMax, float yMin, float Ymax,int numberOfZones)
    {
        float[,,] zoneList = new float[4,numberOfZones,3];
        //[xmin of zone,zone number,zone set number] 
        //zone 1 horizontal
        zoneList[0,0,0] = xMin;
        zoneList[1, 0, 0] = xMin / numberOfZones;
        zoneList[2, 0, 0] = xMin;
        zoneList[3, 0, 0] = xMin;

    }
   */
}
