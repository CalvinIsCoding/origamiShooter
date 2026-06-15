using UnityEngine;
using UnityEngine.UIElements;

public class ScreenShake : MonoBehaviour
{
    public float strength;

    [Range(0.0f, 10.0f)]
    public float smoothTime;
    [Range(0.0f, 10.0f)]
    public float strengthVelocity;
    [Range(0.0f, 10.0f)]
    public float targetStrength;

    public bool shaking;
    public bool screenRed;

    public FireMode firemode;
    public SpriteRenderer redFilter;
 
    public float redFilterOpacity;
    [Range(0.0f, 10.0f)]
    public float targetOpacity;
    [Range(0.0f, 10.0f)]
    public float filterVelocity;
    [Range(0.0f, 10.0f)]
    public float filterSmoothTime;

    Color filterColor = new Color (1f,0f,0f,0f);

    public float lastCoupleSeconds;
    void Start()
    {
        redFilterOpacity = 0f;
        strength = 0f;
        shaking = false;
        screenRed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( firemode.moneyMultiplierTimeElapsed >= (firemode.moneyMultiplierTimer - lastCoupleSeconds) && firemode.liveActivators > 0)
        {
            shaking = true;
            screenRed = true;
        }
        else
        {
            shaking = false;
            screenRed = false;
        }
        screenShaking(shaking);
        turnScreenRed(screenRed);
        
    }

    void screenShaking(bool shaking)
    {
        if (shaking)
        {
            float randomX = Random.value - 0.5f;
            float randomY = Random.value - 0.5f;
            float randomZ = Random.value - 0.5f;
            strength = Mathf.SmoothDamp(strength, targetStrength, ref strengthVelocity, smoothTime);
            // strength = Mathf.SmoothStep()

            transform.localEulerAngles = new Vector3(randomX, randomY, randomZ) * strength;

        }
        else
        {
            strength = 0f;
        }

    }
    void turnScreenRed(bool screenRed)
    {
        if (screenRed)
        {
            
            redFilterOpacity = Mathf.SmoothDamp(redFilterOpacity, targetOpacity, ref filterVelocity, filterSmoothTime);
            // strength = Mathf.SmoothStep()

            //transform.localEulerAngles = new Vector3(randomX, randomY, randomZ) * strength;

        }
        else
        {
            redFilterOpacity = 0f;
        }
        filterColor.a = redFilterOpacity;
        redFilter.color = filterColor;
        
    }

}

