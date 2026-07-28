using UnityEngine;

public class FireBallProjectile : Enemy
{
    //public Rigidbody2D rbFireball;
    public float startingForce;
    public Vector2 startingForceVector;
   // public Enemy enemy;
    bool forceHasBeenAdded;
    void Start()
    {
       // Debug.Log(rb.rotation + "rotation");
        // startingForceVector = new Vector2(Mathf.Sin(rb.rotation), Mathf.Cos(rb.rotation));

        forceHasBeenAdded = false;
        Destroy(this.gameObject,3f);
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
    public override void Push(float knockBack, Rigidbody2D bullet, GameObject _bullet, Vector2 airBulletVelocity)
    {
        
        //nothing
        return;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wall wall = collision.gameObject.GetComponent<Wall>();
        Player player = collision.gameObject.GetComponent<Player>();

        if (wall != null || player != null)
        {
            Destroy(this.gameObject);
        }

    }


}
