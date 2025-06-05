using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class MoneyMultiplierBar : MonoBehaviour
{
    public Slider slider;
    public Text moneyMultiplierText;
    public TMP_Text enemiesKilledText;
    public Animator animator;
    public int multiplierInteger;
    public int enemiesKilled;
    public int numberOfEnemiesSpawned;
    public GameStatsScript gameStats;
    public Image sliderFill;
    
    public void SetMaxMoneyMultiplier(float maxMultiplier)
    {
        slider.maxValue = maxMultiplier;
        //moneyMultiplierText.text = maxMultiplier.ToString();
        //slider.value = overheat;
    }
    public void SetMoneyMultiplierBar(float multiplier,bool isFireMode)
    {
        if (!isFireMode)
        {
            sliderFill.color = Color.red;
            slider.value = multiplier;
            moneyMultiplierText.text = multiplier.ToString();
            multiplierInteger = (int)multiplier;
            animator.SetInteger("Multiplier", multiplierInteger);
            enemiesKilledText.text = gameStats.enemiesKilledThisWave.ToString();
            Debug.Log("enemies Killed " + gameStats.enemiesKilledThisWave);
        }
        if (isFireMode)
        {
            //when fire mode I want to reuse the same slider object in order to reduce UI clutter. The bar will fill from bottom to top when it switches to indicate the number of enemies killed.
            sliderFill.color = Color.blue;
            slider.maxValue = gameStats.enemiesSpawnedThisWave;
            slider.value = gameStats.enemiesKilledThisWave;
            enemiesKilledText.text = gameStats.enemiesKilledThisWave.ToString();
            //moneyMultiplierText.text = multiplier.ToString();
            //multiplierInteger = (int)multiplier;
            //animator.SetInteger("Multiplier", multiplierInteger);
        }
        
    }
}
