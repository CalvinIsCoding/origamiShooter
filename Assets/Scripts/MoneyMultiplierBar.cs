using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMultiplierBar : MonoBehaviour
{
    public Slider slider;
    public Text moneyMultiplierText;
    public Text enemiesKilledText;
    public Animator animator;
    public int multiplierInteger;
    public int enemiesKilled;
    public int numberOfEnemiesSpawned;
    
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
            slider.value = multiplier;
            moneyMultiplierText.text = multiplier.ToString();
            multiplierInteger = (int)multiplier;
            animator.SetInteger("Multiplier", multiplierInteger);
        }
        if (isFireMode)
        {
            //when fire mode I want to reuse the same slider object in order to reduce UI clutter. The bar will fill from bottom to top when it switches to indicate the number of enemies killed.
            slider.maxValue = numberOfEnemiesSpawned;
            slider.value = enemiesKilled;
            enemiesKilledText.text = enemiesKilled.ToString();
            //moneyMultiplierText.text = multiplier.ToString();
            //multiplierInteger = (int)multiplier;
            //animator.SetInteger("Multiplier", multiplierInteger);
        }
        
    }
}
