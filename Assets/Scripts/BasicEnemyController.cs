using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    //public GameObject enemy;
    public GameObject player;
    public BoxCollider2D bc;
    public SpriteRenderer paperPlaneSprite;
    public float angle;
    //public Rigidbody2D rb;



    private float speed;
    private float lastTime;
    private float spawnDelayTime = 0.8f;
    private bool spriteToggle;
    private int blinks = 6;

    void Start()
    {
        bc.enabled = false;

        spriteToggle = false;
        StartCoroutine(Blink());

        player = GameObject.FindWithTag("Player");

        lastTime = Time.time;

        speed = 0f;
       

    }
    



    void Update()
    {
        if(lastTime - Time.time < -spawnDelayTime && !bc.enabled)
        {
            
            bc.enabled = true;
            speed = 0.5f;
        }



        
            Vector3 direction = player.transform.position - this.transform.position;
            angle = Mathf.Atan2(direction.y, direction.x);
            this.transform.rotation = Quaternion.Euler(0f, 0f, angle * (180 / Mathf.PI));

            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        
       
    }

    IEnumerator Blink()
    {
        for (int i = 0; i < blinks; i++)
        {
            paperPlaneSprite.enabled = spriteToggle;
            spriteToggle = !spriteToggle;
            yield return new WaitForSeconds(spawnDelayTime/blinks);
        }
        
    }
}
