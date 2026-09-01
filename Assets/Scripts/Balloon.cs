using UnityEngine;

public class Balloon : MonoBehaviour
{
    public PlayerController player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(0.3f + player.overHeatTime/4f, 0.3f + player.overHeatTime/3.5f, 0.3f + player.overHeatTime/4f);

        if(player.overHeating == true)
        {
            Destroy(this.gameObject);
        }
    }
}
