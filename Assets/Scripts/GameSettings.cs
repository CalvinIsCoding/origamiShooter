using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/New Game Settings Object")]

public class GameSettings : ScriptableObject
{
    public float sfxVolume;
    public float musicVolume;
    public float brightness;
    
    public void changeSettingsValue(string setting,float value)
    {
        if(string.IsNullOrEmpty(setting))
        {
            return;
        }
        else if(setting == "sfxVolume")
        {
            sfxVolume = value;
        }
        else if (setting == "musicVolume")
        {
            musicVolume = value;
        }
        else if (setting == "brightness")
        {
            brightness = value;
        }

    }
    


}
