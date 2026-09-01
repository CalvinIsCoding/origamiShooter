using System.Collections;
using UnityEngine;

public class WhiteOutGrates : MonoBehaviour
{
    public EnemySpawn enemySpawn;
    public SpriteRenderer sprite;
    public Animator grateAnimator;
    public GameObject grates;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator WhiteOut()
    {
        for (int i = 1; i < 45; i++)
        {
            sprite.color = Color.Lerp(Color.clear, Color.white,i/50f);
            yield return new WaitForSeconds(0.05f);
        }
        grateAnimator.SetBool("grate Dissappearing", true);
        grates.SetActive(false);
        Destroy(this.gameObject, 0.4f);
    }


}
