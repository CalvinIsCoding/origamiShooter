using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetPaper : MonoBehaviour
{
    public Enemy enemy;
    void Start()
    {
        enemy.isWet = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
