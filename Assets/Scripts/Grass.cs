using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public Animator animator;
    public Collider2D airBullet;
    private int overlaps;
    //public bool isTouchingAir;
    void Start()
    {
        overlaps = 0;
        //isTouchingAir = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isTouching(airBullet))
        {
            animator.SetBool("isTouchingAir", false);
        }
        else
        {
            animator.SetBool("isTouchingAir", true);

        }*/
        if (overlaps > 0)
        {
            animator.SetBool("isTouchingAir", true);
        }
        else
        {
            animator.SetBool("isTouchingAir", false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       AirBullet airBullet = collision.GetComponent<AirBullet>();

        if(airBullet != null)
        {
           // animator.SetBool("isTouchingAir", true);
            overlaps = overlaps + 1;
        }
        
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        AirBullet airBullet = collision.GetComponent<AirBullet>();
        //animator.SetBool("isTouchingAir", false);
        if (airBullet != null)
        {
            overlaps = overlaps - 1;
        }

    }


    /*public bool isTouching(Collider2D collider)
    {
        AirBullet airBullet = collider.GetComponent<AirBullet>();

        if (airBullet != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }*/




}
