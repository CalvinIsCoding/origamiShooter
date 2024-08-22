using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerNailProjectile : MonoBehaviour
{
    public GameObject bullet;
    public Rigidbody2D rb;
    public float speed = 10f;
   
    public int bulletDamage = 100;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(bullet, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        


        

        
        
            Destroy(bullet);
        


    }
}
