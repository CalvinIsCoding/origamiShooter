using System.Collections;
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

    Color filterColor = new Color(1f, 0f, 0f, 0f);

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
        

    }

    public void ShakeRampUp(float targetStrength = 2f, float strengthVelocityFloat = 1f, float smoothTime = 3f)
    {
        //I allow people to use a custom strength value
       
            strength = Mathf.SmoothDamp(strength, targetStrength, ref strengthVelocityFloat, smoothTime);
            // strength = Mathf.SmoothStep()

            float randomX = Random.value - 0.5f;
            float randomY = Random.value - 0.5f;
            float randomZ = Random.value - 0.5f;

            transform.localEulerAngles = new Vector3(randomX, randomY, randomZ) * strength;
            
        
            
        

    }
    public void ShakeRampDown(float strengthVelocity = 2f, float smoothTime = 0.5f)
    {/*
        for (int i = 0; i < 50; i++)
        {
            strength = Mathf.SmoothDamp(strength, 0f, ref strengthVelocity, smoothTime);
            // strength = Mathf.SmoothStep()

            float randomX = Random.value - 0.5f;
            float randomY = Random.value - 0.5f;
            float randomZ = Random.value - 0.5f;

            transform.localEulerAngles = new Vector3(randomX, randomY, randomZ) * strength;
            yield return new WaitForSeconds(smoothTime / 50);
        }
        */
        strength = 0f;
    }
    public IEnumerator ShakeJolt(float strength = 2f, float strengthVelocity = 1f, float smoothTime = 0.1f)
    {
        for (int i = 0; i < 15; i++)
        {
            strength = Mathf.SmoothDamp(strength, 0f, ref strengthVelocity, smoothTime);
            // strength = Mathf.SmoothStep()

            float randomX = Random.value - 0.5f;
            float randomY = Random.value - 0.5f;
            float randomZ = Random.value - 0.5f;

            transform.localEulerAngles = new Vector3(randomX, randomY, 0f) * strength;

            yield return new WaitForSeconds(smoothTime / 15);
        }
    }
    

    public void turnScreenRed(bool screenRed)
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


