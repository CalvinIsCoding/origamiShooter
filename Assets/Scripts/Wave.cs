using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave : MonoBehaviour
{
    public GameObject[] enemy = new GameObject[5];
    public int[] enemyTypeSpawnChances = new int[5];
    public int[] spawnEventChances = new int[5];
    public int[] spawnTypeRandomizer = new int[100];
    public int[] spawnEventRandomizer = new int[100];
    public bool bossWave;
    public bool specialWave;
    public bool endCriteria;

    public float testNumber = 10f;

    void Start()
    {
        SetSpawnChance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpawnChance()
    {

        int j = 0;
        int counter = 0;
        for (int i = 0; i < 100; i++)
        {
            //Enemy Type Spawn Chances are Set in the Unity Editor. 
            //This array of 100 ints simply has entires equal to the %spawn chance set.
            // a Spawn chance set to 20, will get 20 entries in spawnTypeRandomizer. This is jsut represented by an int
            // The int corresponds to the array position of an enemy in the enemy list.

            //The counter simply increases by 1 everytime the number of entries required for the enemy is satisfied.
            if (counter == enemyTypeSpawnChances[j])
            {
                counter = 0;
                j++;
            }

            spawnTypeRandomizer[i] = j;
            counter++;

        }

        j = 0;
        counter = 0;
        for (int i = 0; i < 100; i++)
        {
            //This works identically to the above for loop but now with spawn events.
            
            if (counter == spawnEventChances[j])
            {
                counter = 0;
                j++;
            }
            if (spawnEventChances[j] > 0)
            {
                spawnEventRandomizer[i] = j;
                counter++;
            }
            else
            {
                i--;
            }
                

        }


    }
}
