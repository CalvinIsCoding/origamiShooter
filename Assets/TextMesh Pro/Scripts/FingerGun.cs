using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerGun : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public BoxCollider2D bc;
    public float angle;
    public Transform firePoint;
    public GameObject bulletPrefab;
    private GameObject bullet;
    
    //public Rigidbody2D rb;



    private float speed = 0.1f;
    private float lastTime;
    private float spawnDelayTime = 0.5f;

    Coroutine myCoroutine;

    void Start()
    {
        bc.enabled = false;

        player = GameObject.FindWithTag("Player");

        lastTime = Time.time;


        myCoroutine = StartCoroutine(Shoot());
    }




    void Update()
    {
        if (lastTime - Time.time < -spawnDelayTime && !bc.enabled)
        {
            bc.enabled = true;
        }

        Vector3 direction = player.transform.position - this.transform.position;
        angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

        
        

       

    }
    IEnumerator Shoot()
    {




        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
    
}
