using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Clock : MonoBehaviour
{
    public GameObject RomanNumeral;
    public float dashSpeed;
    public int numberOfDashes;
    public GameObject player;
    public Rigidbody2D clockRb;
    public Rigidbody2D playerRb;
    public float angle;
    public Vector2 direction;
    public int attackType;
    public bool attackOccurring;
    public SpriteRenderer clockSprite;
    public Vector3 clockSpawnArea;
    public GameObject timerUI;
    public List<Vector2> cornerCoordinates = new List<Vector2>(4);
    public GameObject romanNumeral;
    public GameObject firePoint;


    void Start()
    {
        timerUI = GameObject.FindWithTag("timerUI");
        Debug.Log("corner Coordinate array size" + cornerCoordinates.Count);
        cornerCoordinates[0] = new Vector2(-1.5f, -0.7f);
        cornerCoordinates[1] = new Vector3(-1.5f, 0.5f, 0f);
        cornerCoordinates[2] = new Vector3(1.5f, -0.7f, 0f);
        cornerCoordinates[3] = new Vector3(1.5f, 0.5f, 0f);
    }
    void OnEnable()
    {
        timerUI = GameObject.FindWithTag("timerUI");
        clockSpawnArea = Camera.main.ScreenToWorldPoint(timerUI.transform.position);
        this.transform.position = new Vector3(clockSpawnArea.x - 1.5f, clockSpawnArea.y + 0.8f, 0f);
        
        Debug.Log("Clock Spawn" + clockSpawnArea);
        player = GameObject.FindWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        attackOccurring = false;
    }
    

   
    void Update()
    {
        if (!attackOccurring)
        {
            clockSprite.color = Color.white;
            attackType = UnityEngine.Random.Range(1, 3);

            switch (attackType)
            {
                case 1:
                    StartCoroutine(DashAttack());
                    break;

                case 2:
                    StartCoroutine(ShootNumeralsAttack());
                    break;

            }
        }

    }
    public void Dash()
    {
        
        clockRb.AddForce(direction.normalized * dashSpeed,ForceMode2D.Impulse);
    }
    public void ShootRomanNumerals(float angleShooting)
    {
        float realAngleShooting = angleShooting -( 20f * Mathf.PI/  180f);
        for (int i = 0; i < 3; i++)
        {
            firePoint.transform.rotation = Quaternion.Euler(0, 0, (realAngleShooting * Mathf.Rad2Deg) - 90);
            firePoint.transform.localPosition = new Vector2(Mathf.Cos(realAngleShooting) * 1f, Mathf.Sin(realAngleShooting) * 1f);
            Instantiate(romanNumeral, firePoint.transform.position, firePoint.transform.rotation);
            realAngleShooting += (20f * Mathf.PI / 180f);
        }

    }
    
    public void BlowAir()
    {

    }
    public void FireActivated()
    {

    }
    public void TimesUpClockAttacks()
    {

    }
    public void Orient()
    {
        direction = playerRb.position - clockRb.position;
        angle = Mathf.Atan2(direction.y, direction.x);

        
    }
    IEnumerator ShootNumeralsAttack()
    {
        attackOccurring = true;
        for (int i = 0; i < 4; i++)
        {
            int randomCorner = UnityEngine.Random.Range(0, 4);

            float angleShooting;
            clockSprite.color = Color.clear;
            this.transform.position = cornerCoordinates[randomCorner];
            yield return new WaitForSeconds(0.2f);

            angleShooting = Mathf.Atan2(-cornerCoordinates[randomCorner].y - 0.1f, -cornerCoordinates[randomCorner].x);
           
            clockSprite.color = Color.white;
            ShootRomanNumerals(angleShooting);
            yield return new WaitForSeconds(1f);
           
        }
        clockSprite.color = Color.green;
        yield return new WaitForSeconds(1f);
        attackOccurring = false;

    }
    IEnumerator DashAttack()
    {
        attackOccurring = true;
        for (int i = 0; i < numberOfDashes; i++)
        {
           
            Orient();
            yield return new WaitForSeconds(0.15f);
            Dash();
            yield return new WaitForSeconds(0.7f);
            clockRb.linearVelocity = Vector3.zero;
            


        }
        Rest();
        yield return new WaitForSeconds(1f);
        attackOccurring = false;
    }
    void Rest()
    {
        clockSprite.color = Color.blue;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.PlayerDeath(false);
                
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.PlayerDeath(false);

        }

    }




}
