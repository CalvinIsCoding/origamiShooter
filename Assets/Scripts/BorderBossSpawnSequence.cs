using NUnit.Framework.Constraints;
using System.Collections;
using TMPro;
using UnityEngine;

public class BorderBossSpawnSequence : MonoBehaviour
{
    public WhiteOutGrates grates;
    public Vector3 targetPosition = new Vector2(0f, 0.75f);
    public BorderBoss borderBoss;
    public Rigidbody2D rb;

    void Start()
    {
        grates = FindAnyObjectByType<WhiteOutGrates>();
        StartCoroutine(grates.WhiteOut());
    }

    // Update is called once per frame
    void Update()
    {
        if(grates == null)
        {
            //  rb.MovePosition(targetPosition);
            this.gameObject.transform.position = Vector2.Lerp(this.gameObject.transform.position, targetPosition, 0.008f);
        }
        if(this.gameObject.transform.position.y < 0.76f)
        {
            borderBoss.enabled = true;
            this.enabled = false;
        }
        
    }
   
    public IEnumerator BossInPlace()
    {

        yield return null;
    }
  

}
        
    


