using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    public int bulletDamage = 101;
    public int radius = 10;
    public float explosionTime = 1.5f;

    void Start()
    {
        Destroy(explosion, explosionTime);
        //Border.instance.DestroyBorder(transform.position, radius);
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (enemy != null)
        {
            
            enemy.Die(false);
            

        }
    
        /*if (border != null)
        {
            Border.instance.DestroyBorder(transform.position, radius);
        }*/

        
    }

}
