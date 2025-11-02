using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleScreenWall : MonoBehaviour
{
    public EdgeCollider2D edgeCollider;
    public BoxCollider2D arenaBoundsCheck;
    public 
    void Start()
    {
        edgeCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if(InsideCol(player.gameObject.GetComponent<CircleCollider2D>(),collision))
            {
                player.insideArenaBound = true;
                edgeCollider.enabled = true;
            } 
            
        }

    }

    bool InsideCol(Collider2D mycol, Collider2D other)
    {
        if (other.bounds.Contains(mycol.bounds.min)
             && other.bounds.Contains(mycol.bounds.max))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
