using UnityEngine;

public class RomanNumeral : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingForce;
    public Vector2 startingForceVector;
    public Enemy enemy;
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
        if(!enemy.isBlink && !forceHasBeenAdded)
        {
            rb.AddRelativeForce(new Vector2(0, startingForce), ForceMode2D.Impulse);
            forceHasBeenAdded = true;
        }
        else
        {

        }
    }
    

}
