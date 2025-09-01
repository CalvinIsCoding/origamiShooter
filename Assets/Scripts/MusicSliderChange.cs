using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderChange : MonoBehaviour
{
    public GameSettings settings;
    public Slider musicSlider;
    void Start()
    {
        musicSlider.value = settings.musicVolume;
    }

   
    public void setMusicVolume()
    {
        settings.musicVolume = musicSlider.value;
    }

}
