using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBomb : MonoBehaviour
{
    public GameObject waterBomb;
    public GameObject waterBombExplosion;
    public BoxCollider2D bc;
    public float waterBombTimer = 4f;
    void Start()
    {
        StartCoroutine(TimeBomb());
        Destroy(waterBomb, waterBombTimer + 0.1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TimeBomb()
    {
        yield return new WaitForSeconds(waterBombTimer);
        Instantiate(waterBombExplosion, bc.transform.position, bc.transform.rotation);

    }

    
}
