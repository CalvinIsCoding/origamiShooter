using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SfxSliderChange : MonoBehaviour
{
    public GameSettings settings;
    public Slider sfxSlider;
    void Start()
    {
        sfxSlider.value = settings.sfxVolume;
    }


    public void setSFXVolume()
    {
        settings.sfxVolume = sfxSlider.value;
    }
}
