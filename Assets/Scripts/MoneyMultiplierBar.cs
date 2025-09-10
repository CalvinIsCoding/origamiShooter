using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class MoneyMultiplierBar : MonoBehaviour
{
    public Slider slider;
    public TMP_Text enemiesKilledText;
    public TMP_Text moneyMultiplierText;
    public int multiplierInteger;
    public int enemiesKilled;
    public int numberOfEnemiesSpawned;
    public GameStatsScript gameStats;
    public PlayerInventory playerInventory;
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
            slider.maxValue = 10f;
            slider.value = multiplier;

            moneyMultiplierText.SetText(MathF.Ceiling(multiplier).ToString()); 
            multiplierInteger = (int)MathF.Ceiling(multiplier);
            //animator.SetInteger("Multiplier", multiplierInteger);
            enemiesKilledText.text = playerInventory.coinsBeforeMultiplier.ToString();
           // Debug.Log("max multiplier" + );
        }
        if (isFireMode)
        {
            //when fire mode I want to reuse the same slider object in order to reduce UI clutter. The bar will fill from bottom to top when it switches to indicate the number of enemies killed.
            sliderFill.color = Color.blue;
            slider.maxValue = gameStats.enemiesSpawnedThisWave;
            slider.value = playerInventory.coinsBeforeMultiplier;

            enemiesKilledText.text = playerInventory.coinsBeforeMultiplier.ToString();
            //moneyMultiplierText.text = multiplier.ToString();
            //multiplierInteger = (int)multiplier;
            //animator.SetInteger("Multiplier", multiplierInteger);
        }
        
    }
}
