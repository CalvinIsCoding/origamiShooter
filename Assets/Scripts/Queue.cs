using System.Collections;
using UnityEngine;

public class Queue : Enemy
{
    //public Rigidbody2D rbFireball;
    public float startingForce;
    public Vector2 startingForceVector;
    public GameObject explosion;
    public float deathTime;
   // public Enemy enemy;
    bool forceHasBeenAdded;
    bool justSpawned;
    void Start()
    {
        // Debug.Log(rb.rotation + "rotation");
        // startingForceVector = new Vector2(Mathf.Sin(rb.rotation), Mathf.Cos(rb.rotation));
        justSpawned = true;
        forceHasBeenAdded = false;
        Destroy(this.gameObject,deathTime);
       //rb.linearVelocity = new Vector2 (0f, startingForce);
       StartCoroutine(EnableHittingBoss());
    }

    // Update is called once per frame
    void Update()
    {
        if(!forceHasBeenAdded)
        {
            rb.AddRelativeForce(new Vector2(-startingForce, 0f), ForceMode2D.Impulse);
            forceHasBeenAdded = true;
        }
        else
        {

        }
    }
    public void OnDestroy()
    {
        Instantiate(explosion,this.transform.position,this.transform.rotation);
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {

        Boss boss = collision.GetComponentInParent<Boss>();

        // BossAppendage appendage = collision.GetComponent<BossAppendage>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (boss != null && justSpawned == false)
        {
            
           
            
            Destroy(this.gameObject);
            //boss.TakeDamage(10);



        }

        
        /*
        if (border != null)
        {
            Border.instance.DestroyBorder(transform.position, radius);
        }
        */

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        Boss boss = collision.gameObject.GetComponentInParent<Boss>();
        if (player != null)
        {
            Destroy(this.gameObject);
        }
        if (boss != null && justSpawned == false)
        {
            //Debug.Log("Destroying Queue");
            

            Destroy(this.gameObject);
           // boss.TakeDamage(10);



        }
    }

    public IEnumerator EnableHittingBoss()
    {
        yield return new WaitForSeconds(0.4f);
        justSpawned = false;
    }



}
