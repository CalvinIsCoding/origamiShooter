using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AirBulletBack : AirBullet
{
   
   
    void OnEnable()
    {

        rb.linearVelocity = transform.right * playerInventory.airBulletSpeed;
        //Destroy(airBullet, 1.0f);
        //Object Pooling

       // knockBack = 15f; //+ (fanBlades.numberPurchased * fanBlades.modifier);
        
            bulletLivingTime = universalTimers.defaultBulletLivingTime / 2f;
        shrinkTime = playerInventory.BulletShrinkTime;
        
        knockBack = playerInventory.knockBack;

        DefaultAirBulletScale = playerInventory.backBulletSizeDefault;//playerInventory.backBulletSizeDefault;
        currentAirBulletScale = playerInventory.backBulletSize;//playerInventory.backBulletSize;
        StartCoroutine(ShrinkBullets());
        StartCoroutine(DeactivateBullets());
    }
   
}
