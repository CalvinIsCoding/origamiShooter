using UnityEngine;

public class SpinClockHand : MonoBehaviour
{
   public  Rigidbody2D rb;
    public Transform clockHandTransform;
    public MoneyMultiplierBar moneyMultiplierBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // rb.rotation = -moneyMultiplierBar.slider.value * 180;
        clockHandTransform.localEulerAngles = new Vector3(0,0,-moneyMultiplierBar.slider.value * 30);
    }
}
