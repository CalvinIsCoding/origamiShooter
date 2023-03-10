using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Random = System.Random;
//using System;
using System.Linq;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[5];


    public int paperPlaneSpawnChance = 90;
    public int redPlaneSpawnChance = 5;
    public int redCircleSpawnChance = 5;
    private int[] enemyTypeSpawnChances = new int[3];
    
    private int typeSpawned;


    public int[] spawnTypeRandomizer = new int[100];

    
    public float x, y, _x, _y;
    private float lastTime;
    private float timeStep;

    private float spawnMany_timeStep;
    private int spawnManyTrigger;
  
    private float numberSpawned;
    private int spawnMany_howOften;

    private int spawnRedTrigger;
    private float spawnRed_howOften;

    private float xMin = -1.477f;
    private float xMax = 1.339f;
    private float yMin = -.75f;
    private float yMax = 0.70f;

    public Transform playerPosition;
    private float noSpawnRadius = 0.35f;
    private bool isNearPlayer = false;
    private float noSpawn_xMin;
    private float noSpawn_xMax;
    private float noSpawn_yMin;
    private float noSpawn_yMax;



    void Start()
    {
        
        enemyTypeSpawnChances[0] = paperPlaneSpawnChance;
        enemyTypeSpawnChances[1] = redPlaneSpawnChance;
        enemyTypeSpawnChances[2] = redCircleSpawnChance;
        SetSpawnChance();
        lastTime = 0f;
        timeStep = 2f;
        spawnMany_timeStep = 0.01f;

        //Changes how often a "spawn many" event occurs. wherein a large group of enemies is spawned near the player. Lowering the multiplier decreases the time between spawn many events
        spawnMany_howOften = (int)timeStep * 5;


       
    

}

    void FixedUpdate()
    {

            noSpawn_xMin = playerPosition.position.x - noSpawnRadius;
            noSpawn_xMax = playerPosition.position.x + noSpawnRadius;
            noSpawn_yMin = playerPosition.position.y - noSpawnRadius;
             noSpawn_yMax = playerPosition.position.y + noSpawnRadius;
    }




       

        
   












// enemies should probably spawn blinking for a second.

void Update()
    {

        if (lastTime - Time.time < -timeStep)
        {


            Spawn();

            lastTime = Time.time;

            spawnManyTrigger = Random.Range(0, spawnMany_howOften);
            


            //timeStep = timeStep - 0.01f;
        }


        if (spawnManyTrigger == (Mathf.Round(spawnMany_howOften / 2f)))
        {
            StartCoroutine(SpawnMany());
            spawnManyTrigger--;
            //maybe add a cooldown and a maximum amount of time that can pass before another spawn many instance?

        }

        



    }

    void Spawn()
    {
        numberSpawned = Random.Range(1, 4);
        typeSpawned = spawnTypeRandomizer[Random.Range(1, 100)];
        

        for (int i = 0; i < numberSpawned; i++)
        {
            Vector2 spawnPos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            //Checks if a randomly selected coordinate is within a certain radius of the player
            isNearPlayer = Mathf.Sqrt((Mathf.Pow((playerPosition.position.x - spawnPos.x), 2) + Mathf.Pow((playerPosition.position.y - spawnPos.y), 2))) < noSpawnRadius;

            
            if (!isNearPlayer)
            {
                Instantiate(enemy[typeSpawned], spawnPos, Quaternion.identity);
            }
            else if (isNearPlayer)
            {
                //check sign of each coordinate, and change the location by the value of radius
                spawnPos.x = (spawnPos.x / Mathf.Abs(spawnPos.x)) * -noSpawnRadius;
                spawnPos.y = (spawnPos.y / Mathf.Abs(spawnPos.y)) * -noSpawnRadius;
                Instantiate(enemy[typeSpawned], spawnPos, Quaternion.identity);
            }
            
        }

    }

    IEnumerator SpawnMany()
    {


        for (int i = 0; i < 8; i++)
        {




            Vector2 spawnPos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            lastTime = Time.time;
            typeSpawned = spawnTypeRandomizer[Random.Range(1, 100)];
            if (Mathf.Sqrt((Mathf.Pow((playerPosition.position.x - spawnPos.x), 2) + Mathf.Pow((playerPosition.position.y - spawnPos.y), 2))) > noSpawnRadius)
            {
                Instantiate(enemy[typeSpawned], spawnPos, Quaternion.identity);
            }

            //Instantiate(enemy, new Vector3(_x, _y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnMany_timeStep);


        }


    }
    void SetSpawnChance()
    {
        
        int j = 0;
        int counter = 0;
       for (int i = 0; i < 100; i++)
        {
            if(counter == enemyTypeSpawnChances[j])
            {
                counter = 0;
                j++;
            }

            spawnTypeRandomizer[i] = j;
            counter++;
           
        }
        
        
    }
    
}
