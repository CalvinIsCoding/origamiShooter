using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;
//using System;
using System.Linq;

public class EnemySpawn : MonoBehaviour
{
    // public GameObject[] enemy = new GameObject[5];

    //[SerializeField]
    public Wave[] wave = new Wave[10];
    
    public int waveNumber;
    public int lastWave;

    public FireMode fireMode;
  /*  public int paperPlaneSpawnChance = 90;
    public int redPlaneSpawnChance = 5;
    public int redCircleSpawnChance = 5;*/
    //public int[] enemyTypeSpawnChances = new int[5];
    
    private int typeSpawned;


    public int[] spawnTypeRandomizer = new int[100];
    public int[] spawnEventRandomizer = new int[100];
    private int eventSelect;

    
    public float x, y, _x, _y;
    private float lastTime;
    public float timeBetweenSpawns;
    public int maxSimultaneouslySpawned;

    private float spawnEvent_timeStep;
    private int spawnEventTrigger;
  
    private int numberSpawned;
    private int spawnEvent_howOften;
    private bool spawningComplete;

    private int spawnRedTrigger;
    private float spawnRed_howOften;

    [HideInInspector] public float xMin;
    [HideInInspector] public float xMax;
    [HideInInspector] public float yMin;
    [HideInInspector] public float yMax;

    public Transform playerPosition;
    private float noSpawnRadius = 0.35f;
    private bool isNearPlayer = false;
    private float noSpawn_xMin;
    private float noSpawn_xMax;
    private float noSpawn_yMin;
    private float noSpawn_yMax;

    private GameObject fireActivator;

    public GameObject shop;
    private bool shopSpawned;

    public GameStatsScript gameStats;

    public float bossWaitTime;

    void Start()
    {
        bossWaitTime = 5f;
        /*  enemyTypeSpawnChances[0] = paperPlaneSpawnChance;
          enemyTypeSpawnChances[1] = redPlaneSpawnChance;
          enemyTypeSpawnChances[2] = redCircleSpawnChance;*/
        //SetSpawnChance();

        lastTime = 0f;
        timeBetweenSpawns = 1.5f;
        spawnEvent_timeStep = 0.01f;

        //Changes how often a spawn event occurs. wherein a large group of enemies is spawned near the player.
        //Lowering the multiplier decreases the time between spawn events.
        spawnEvent_howOften = (int)timeBetweenSpawns * 5;


        waveNumber = 0;
        lastWave = 0;

        //These are the bounds of the arena (approximately) I should figure out how to do this programmatically maybe
        xMin = -1.6f;
        xMax = 1.6f;
        yMin = -0.85f;
        yMax = 0.6f;

        spawningComplete = false;

        shopSpawned = false;
        maxSimultaneouslySpawned = 3;

    }

    void FixedUpdate()
    {

            noSpawn_xMin = playerPosition.position.x - noSpawnRadius;
            noSpawn_xMax = playerPosition.position.x + noSpawnRadius;
            noSpawn_yMin = playerPosition.position.y - noSpawnRadius;
             noSpawn_yMax = playerPosition.position.y + noSpawnRadius;
    }





    void Update()
    {
        if (wave[waveNumber].specialWave == true && spawningComplete == false)
        {
            //any number would be fine as the index to spawnEventRandomizer. 5 was just chosen randomly.
            SpawnEventSelector(wave[waveNumber].spawnEventRandomizer[5]);

            spawningComplete = true;
        }

        if (!fireMode.isFireMode)
        {

            
            if (lastTime - Time.time < -timeBetweenSpawns && wave[waveNumber].specialWave == false)
            {
                Spawn();
                lastTime = Time.time;
                spawnEventTrigger = Random.Range(0, spawnEvent_howOften);
                //timeBetweenSpawns = timeBetweenSpawns - 0.01f;
            }

            // I want "spawn events" to trigger randomly every so often. These are supposed to be more interesting things like a large group spawning 
            // right around the player, or enemies spawning around all 

            if (spawnEventTrigger == (Mathf.Round(spawnEvent_howOften / 5f)) && wave[waveNumber].specialWave == false)
            {
                //spawn events are put into an array of 100 to determine the chance that a spawn event happens.
                eventSelect = wave[waveNumber].spawnEventRandomizer[Random.Range(1, 100)];
                SpawnEventSelector(eventSelect);
                //StartCoroutine(SpawnMany());
                spawnEventTrigger--;
                //maybe add a cooldown and a maximum amount of time that can pass before another spawn many instance?

            }

        }
        if(waveNumber % 4 == 0 && !shopSpawned && waveNumber != 0)
        {
            SpawnShop();
            maxSimultaneouslySpawned++;
        }
        if(waveNumber % 4 != 0)
        {
            shopSpawned = false;
        }
        
        if(lastWave < waveNumber -1 )
        {
            timeBetweenSpawns = timeBetweenSpawns - 0.1f;
            Debug.Log("time between Spawns" + timeBetweenSpawns);
            lastWave = waveNumber;
        }


    }


    // This is regular random spawn. Enemies spawn some distance away from the player at any coordinate in the arena. 
    // 
    void Spawn(string spawnMode = "default")
    {
        if (spawnMode == "spawnFixed")
        {
            numberSpawned = 1;
        }
        else
        {
            numberSpawned = Random.Range(1, maxSimultaneouslySpawned);
        }
        
        typeSpawned = wave[waveNumber].spawnTypeRandomizer[Random.Range(1, 100)];
        

        for (int i = 0; i < numberSpawned; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
           // Debug.Log("xMax:" + xMax);
           // Debug.Log("yMax:" + yMax);
           // Debug.Log("xMin:" + xMin);
           // Debug.Log("yMin:" + yMin);

            // Checks if a randomly selected coordinate is within a certain radius of the player
            isNearPlayer = Mathf.Sqrt((Mathf.Pow((playerPosition.position.x - spawnPos.x), 2) + Mathf.Pow((playerPosition.position.y - spawnPos.y), 2))) < noSpawnRadius;

            
            if (!isNearPlayer)
            {
                //okay to spawn normally if far enough from player
                Instantiate(wave[waveNumber].enemy[typeSpawned], spawnPos, Quaternion.identity * wave[waveNumber].enemy[typeSpawned].transform.localRotation);
            }
            else if (isNearPlayer)
            {
                //check sign of each coordinate, and change the location by the value of radius
                //This is done to make enemies spawn a minimum distance away from the player
               
                spawnPos.x = spawnPos.x + ( (spawnPos.x / Mathf.Abs(spawnPos.x)) * -noSpawnRadius);
                spawnPos.y = spawnPos.y + ( (spawnPos.y / Mathf.Abs(spawnPos.y)) * -noSpawnRadius);
                
                Instantiate(wave[waveNumber].enemy[typeSpawned], spawnPos, Quaternion.identity * wave[waveNumber].enemy[typeSpawned].transform.localRotation);
            }
            
            
        }
        gameStats.enemiesSpawnedThisWave = gameStats.enemiesSpawnedThisWave + numberSpawned;
        gameStats.totalEnemiesSpawned = gameStats.totalEnemiesSpawned + numberSpawned;

    }

    //The Spawn Event Selector takes in an int and will activate 1 function of a spawn event.
    //This is a way to have regular spawns but also special spawns occasionally.
    void SpawnEventSelector(int spawnEventID)
    {
        switch (spawnEventID)
        {   
            //nothing
            case  0:

                break;
            //spawn many
            case  1:

                StartCoroutine(SpawnMany());
                break;
            //Boss wave
            case 2:
                
                StartCoroutine(SpawnBoss());
                
                break;
            //3 enemies
            case 3:
                int i;
                for (i = 0; i<2; i++)
                {
                    Spawn("spawnFixed");
                }
                break;
        }
    }





    //This is the list of "Spawn Events" so this would be spawning enemies in some chosen way.
    //These events are used to create interesting scenarios for the player that are extremely unlikely to occure during 
    //spawn. 
    IEnumerator SpawnMany()
    {


        for (int i = 0; i < 8; i++)
        {

            Vector2 spawnPos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            lastTime = Time.time;
            typeSpawned = wave[waveNumber].spawnTypeRandomizer[Random.Range(1, 100)];
            if (Mathf.Sqrt((Mathf.Pow((playerPosition.position.x - spawnPos.x), 2) + Mathf.Pow((playerPosition.position.y - spawnPos.y), 2))) > noSpawnRadius)
            {
                Instantiate(wave[waveNumber].enemy[typeSpawned], spawnPos, Quaternion.identity * wave[waveNumber].enemy[typeSpawned].transform.localRotation);
            }

            //Instantiate(enemy, new Vector3(_x, _y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnEvent_timeStep);


        }


    }
    IEnumerator SpawnBoss()
    {
        Vector2 originCoordinates = new Vector2(0, 0); //center of playing field
        yield return new WaitForSeconds(bossWaitTime);
        Instantiate(wave[waveNumber].enemy[0], originCoordinates, Quaternion.identity);
    }

    void SpawnShop()
    {
        Vector2 shopSpawn = new Vector2(0f, 0f);
        Instantiate(shop, shopSpawn, Quaternion.identity);
        shopSpawned = true;
    }
   
    
    
}
