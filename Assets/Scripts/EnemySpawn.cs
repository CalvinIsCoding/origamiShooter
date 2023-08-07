using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;
//using System;
using System.Linq;

public class EnemySpawn : MonoBehaviour
{
    // public GameObject[] enemy = new GameObject[5];

    [SerializeField]
    public Wave[] wave = new Wave[10];
    
    public int waveNumber;

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
    public float timeStep;

    private float spawnEvent_timeStep;
    private int spawnEventTrigger;
  
    private float numberSpawned;
    private int spawnEvent_howOften;

    private int spawnRedTrigger;
    private float spawnRed_howOften;

    private float xMin = -2f;
    private float xMax = 2f;
    private float yMin = -1.25f;
    private float yMax = 0.80f;

    public Transform playerPosition;
    private float noSpawnRadius = 0.35f;
    private bool isNearPlayer = false;
    private float noSpawn_xMin;
    private float noSpawn_xMax;
    private float noSpawn_yMin;
    private float noSpawn_yMax;



    void Start()
    {
        
      /*  enemyTypeSpawnChances[0] = paperPlaneSpawnChance;
        enemyTypeSpawnChances[1] = redPlaneSpawnChance;
        enemyTypeSpawnChances[2] = redCircleSpawnChance;*/
        //SetSpawnChance();
        lastTime = 0f;
        timeStep = 2f;
        spawnEvent_timeStep = 0.01f;

        //Changes how often a spawn event occurs. wherein a large group of enemies is spawned near the player.
        //Lowering the multiplier decreases the time between spawn events.
        spawnEvent_howOften = (int)timeStep * 5;

        waveNumber = 0;



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
        if (!fireMode.isFireMode)
        {


            if (lastTime - Time.time < -timeStep)
            {


                Spawn();

                lastTime = Time.time;

                spawnEventTrigger = Random.Range(0, spawnEvent_howOften);



                //timeStep = timeStep - 0.01f;
            }


            if (spawnEventTrigger == (Mathf.Round(spawnEvent_howOften / 2f)))
            {
                eventSelect = wave[waveNumber].spawnEventRandomizer[Random.Range(1, 100)];
                SpawnEventSelector(eventSelect);
                //StartCoroutine(SpawnMany());
                spawnEventTrigger--;
                //maybe add a cooldown and a maximum amount of time that can pass before another spawn many instance?

            }

        }

        



    }


    // This is regular random spawn. Enemies spawn some distance away from the player at any coordinate in the arena. 
    // 
    void Spawn()
    {
        numberSpawned = Random.Range(1, 4);
        typeSpawned = wave[waveNumber].spawnTypeRandomizer[Random.Range(1, 100)];
        

        for (int i = 0; i < numberSpawned; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            //Checks if a randomly selected coordinate is within a certain radius of the player
            isNearPlayer = Mathf.Sqrt((Mathf.Pow((playerPosition.position.x - spawnPos.x), 2) + Mathf.Pow((playerPosition.position.y - spawnPos.y), 2))) < noSpawnRadius;

            
            if (!isNearPlayer)
            {
                Instantiate(wave[waveNumber].enemy[typeSpawned], spawnPos, Quaternion.identity);
            }
            else if (isNearPlayer)
            {
                //check sign of each coordinate, and change the location by the value of radius
                spawnPos.x = (spawnPos.x / Mathf.Abs(spawnPos.x)) * -noSpawnRadius;
                spawnPos.y = (spawnPos.y / Mathf.Abs(spawnPos.y)) * -noSpawnRadius;
                Instantiate(wave[waveNumber].enemy[typeSpawned], spawnPos, Quaternion.identity);
            }
            
        }

    }

    //The Spawn Event Selector takes in an int and will activate 1 function of a spawn event.
    void SpawnEventSelector(int spawnEventID)
    {
        switch (spawnEventID)
        {
            case  0:

                break;

            case  1:

                StartCoroutine(SpawnMany());
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
                Instantiate(wave[waveNumber].enemy[typeSpawned], spawnPos, Quaternion.identity);
            }

            //Instantiate(enemy, new Vector3(_x, _y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnEvent_timeStep);


        }


    }
    
    
}
