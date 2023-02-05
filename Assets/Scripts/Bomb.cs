using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public GameObject bomb;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        bulletBehavior projectile = collision.GetComponent<bulletBehavior>();
        if (projectile != null)
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(bomb);

        }


        


    }
}
