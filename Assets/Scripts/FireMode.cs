using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMode : MonoBehaviour
{
    private float timeTillFire;
    public float fireModeTime;
    public bool isFireMode;

    public EnemySpawn enemySpawn;
    void Start()
    {
        isFireMode = false;
        
       

        //fireCollider.enabled = true;
        timeTillFire = 10f;
        fireModeTime = 3f;
        isFireMode = false;
        StartCoroutine(EnableFireMode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnableFireMode()
    {
        yield return new WaitForSeconds(timeTillFire);
        StartCoroutine(DisableFireMode());
        //fireCollider.enabled = true;
       
        isFireMode = true;
        
        enemySpawn.timeStep = enemySpawn.timeStep - 0.1f;
        enemySpawn.waveNumber = enemySpawn.waveNumber + 1;




    }
    IEnumerator DisableFireMode()
    {
        yield return new WaitForSeconds(fireModeTime);
        StartCoroutine(EnableFireMode());
        //fireCollider.enabled = false;
        
        isFireMode = false;


    }

}
