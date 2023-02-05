using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryBox : MonoBehaviour
{
    public Transform firePoint;
    public Quaternion direction;
    
    void Start()
    {
        //StartCoroutine(disableParryBox())
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bulletEnemyController bulletEnemy = collision.GetComponent<bulletEnemyController>();
        RedEnemy redEnemy = collision.GetComponent<RedEnemy>();
        if (bulletEnemy != null || redEnemy != null)
        {
            direction = firePoint.rotation;
            //bulletEnemy.Parry(direction);
            redEnemy.Parry(direction);

        }
        else
        {

        }
    }

    
}
