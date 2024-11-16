using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBombExplosion : MonoBehaviour
{
    public GameObject explosion;
    public int bulletDamage = 101;
    public int radius = 10;
    public float explosionTime = 1.5f;

    void Start()
    {
        Destroy(explosion, explosionTime);
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();

       


        if (enemy != null)
        {

            enemy.WettingPaper();


        }

        


    }
}
