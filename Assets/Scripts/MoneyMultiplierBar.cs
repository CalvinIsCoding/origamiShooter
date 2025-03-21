using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyMultiplierBar : MonoBehaviour
{
    public Slider slider;
    public Text moneyMultiplierText;
    
    public void SetMaxMoneyMultiplier(float maxMultiplier)
    {
        slider.maxValue = maxMultiplier;
        //moneyMultiplierText.text = maxMultiplier.ToString();
        //slider.value = overheat;
    }
    public void SetMoneyMultiplierBar(float multiplier)
    {
        slider.value = multiplier;
        moneyMultiplierText.text = multiplier.ToString();
    }
}
