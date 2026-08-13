using UnityEngine;

public class SpinClockHand : MonoBehaviour
{
   public  Rigidbody2D rb;
    public MoneyMultiplierBar moneyMultiplierBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation = -moneyMultiplierBar.slider.value * 180;
    }
}
