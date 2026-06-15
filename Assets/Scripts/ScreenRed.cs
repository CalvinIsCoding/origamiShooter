using UnityEngine;

public class ScreenRed : MonoBehaviour
{
    public GameObject redFilter;
    public FireMode fireMode;
    public ScreenShake screenShake;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireMode.moneyMultiplierTimeElapsed >= fireMode.moneyMultiplierTimer - screenShake.lastCoupleSeconds && fireMode.liveActivators > 0)
        {

        }
    }
}
