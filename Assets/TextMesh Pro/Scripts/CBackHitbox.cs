using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBackHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    cEnemy parentCEnemy;
    void Start()
    {
        parentCEnemy = this.GetComponentInParent<cEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AirBullet collisionObject = collision.GetComponent<AirBullet>();
        if(collisionObject != null)
        {
            parentCEnemy.grow();
        }
    }
}
