using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverheatBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxMoneyMultiplier(float MaxOverheat)
    {
        slider.maxValue = MaxOverheat;
        //slider.value = overheat;
    }
    public void SetMoneyMultiplierBar(float overHeat)
    {
        slider.value = overHeat;
    }
}
