using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public AudioSource globalAudio;
    public AudioClip fireStarting;
    public AudioClip fireEnding;
    public AudioClip victoryTune;
    public bool isBossWave;
    public bool waveHasStarted;
    public BossObject bossObject;
    public bool gameComplete;

    public int moneyEarnedThisRound;
    public moneyEarnedThisRoundProcesser roundMoney;
    public SlamNumbersTogether numberSlammer;

    private bool isNearPlayer;

    public Timers timers;
    public GameSettings gameSettings;

    void Start()
    {
        //resetting the boss defaults here to prevent a bug where bossIsDead is true at the very start of a boss wave before the boss spawns
        bossObject.resetToDefaults();
        waveHasStarted = false;
        
        moneyMultiplier = 0;
        activatorWaitTime = timers.lullAfterFireModeEndsButWaveHasntBegun;
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
        isBossWave = false;
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
        globalAudio.volume = gameSettings.sfxVolume;
       
    }
    void FixedUpdate()
    {
        isBossWave = enemySpawn.wave[enemySpawn.waveNumber].bossWave;
        //Debug.Log("isBosswave" + isBossWave);
       // Debug.Log("wave started" + waveHasStarted);
        if (isBossWave == true && waveHasStarted == false)
        {
            StartCoroutine(BeginBossWave());
            
        }
        
        if (activatorCounter >= requiredActivators && isBossWave == false)
        {
            
            StartFireAndEndWave();

        }
        if (liveActivators == 0 && isBossWave == false)
        {
            SpawnFireActivators();
        }
        if(isBossWave && bossObject.bossIsDead)
        {
           
            StartCoroutine(GameCompletion());
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
        StartCoroutine(numberSlammer.CrunchNumbers());
        StartCoroutine(DelayActivatorSpawn());
        isFireMode = false;
        moneyEarnedThisRound = (int)(playerInventory.coinsBeforeMultiplier * Mathf.Ceil(playerInventory.multiplier));
        Debug.Log("coins before multiplier" + playerInventory.coinsBeforeMultiplier);
        Debug.Log("multiplier" + Mathf.Ceil(playerInventory.multiplier));
        StartCoroutine(roundMoney.setMoneyEarnedThisRound(moneyEarnedThisRound));
        
        gameStats.EndOfWave(enemySpawn.waveNumber);
        playerInventory.EndOfWave();
        enemySpawn.waveNumber = enemySpawn.waveNumber + 1;
        gameStats.wavesSurvived++;
        globalAudio.PlayOneShot(fireEnding);

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
        globalAudio.PlayOneShot(fireStarting);
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


            
            // Debug.Log("xMax:" + xMax);
            // Debug.Log("yMax:" + yMax);
            // Debug.Log("xMin:" + xMin);
            // Debug.Log("yMin:" + yMin);

            // Checks if a randomly selected coordinate is within a certain radius of the player
            


            activatorSpawnPositions[i] = new Vector2(Random.Range(enemySpawn.xMin, enemySpawn.xMax), Random.Range(enemySpawn.yMin, enemySpawn.yMax));

            if (i > 0 && (Mathf.Abs(activatorSpawnPositions[i].x - activatorSpawnPositions[i - 1].x) < 0.2 || Mathf.Abs(activatorSpawnPositions[i].y - activatorSpawnPositions[i - 1].y) < 0.1))
            {
                activatorSpawnPositions[i].x = activatorSpawnPositions[i-1].x * -1;
                activatorSpawnPositions[i].y = activatorSpawnPositions[i-1].y * -1;
            }

            isNearPlayer = Mathf.Sqrt((Mathf.Pow((player.transform.position.x - activatorSpawnPositions[i].x), 2) + Mathf.Pow((player.transform.position.y - activatorSpawnPositions[i].y), 2))) < enemySpawn.noSpawnRadius;


            if (!isNearPlayer)
            {
                //okay to spawn normally if far enough from player

            }
            else if (isNearPlayer)
            {
                //check sign of each coordinate, and change the location by the value of radius
                //This is done to make enemies spawn a minimum distance away from the player

                activatorSpawnPositions[i].x = activatorSpawnPositions[i].x + ((activatorSpawnPositions[i].x / Mathf.Abs(activatorSpawnPositions[i].x)) * -enemySpawn.noSpawnRadius);
                activatorSpawnPositions[i].y = activatorSpawnPositions[i].y + ((activatorSpawnPositions[i].y / Mathf.Abs(activatorSpawnPositions[i].y)) * -enemySpawn.noSpawnRadius);

               
            }


            liveActivators++;
        }

        
        for (int i = 0; i < requiredActivators; i++)
        {
            Instantiate(fireActivator, activatorSpawnPositions[i], Quaternion.identity);
        }


        activatorsSpawned = true;

    }
    IEnumerator BeginBossWave()
    {
        waveHasStarted = true;
        Debug.Log("begin boss wave");
        yield return new WaitForSeconds(enemySpawn.bossWaitTime - 2f);
        isFireMode = true;
    }
    IEnumerator GameCompletion()
    {
        Debug.Log("game Ending");
        //globalAudio.volume = 0.2f;
        globalAudio.PlayOneShot(victoryTune,0.2f);
        yield return new WaitForSeconds(victoryTune.length);
        SceneManager.LoadScene("Game End Screen");

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
