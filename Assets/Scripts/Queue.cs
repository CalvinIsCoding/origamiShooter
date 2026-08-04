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
    void Start()
    {
       // Debug.Log(rb.rotation + "rotation");
        // startingForceVector = new Vector2(Mathf.Sin(rb.rotation), Mathf.Cos(rb.rotation));

        forceHasBeenAdded = false;
        Destroy(this.gameObject,deathTime);
       //rb.linearVelocity = new Vector2 (0f, startingForce);
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
    private void OnDestroy()
    {
        Instantiate(explosion,this.transform.position,this.transform.rotation);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {

        Boss boss = collision.GetComponentInParent<Boss>();
       
       // BossAppendage appendage = collision.GetComponent<BossAppendage>();

        // Border border = collision.GetComponent<Border>();
        // Tilemap tilemap = GetComponent<Tilemap>();


        if (boss != null)
        {
            Debug.Log("Destroying Queue");
            boss.TakeDamage(10);
            
            Destroy(this.gameObject);



        }

        
        /*
        if (border != null)
        {
            Border.instance.DestroyBorder(transform.position, radius);
        }
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(this.gameObject);
        }
    }




}
