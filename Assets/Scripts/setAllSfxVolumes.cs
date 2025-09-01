using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setAllSfxVolumes : MonoBehaviour
{
   GameSettings gameSettings;
    
    public void SetSFXVolume(AudioSource audioSource)
    {
        audioSource.volume = gameSettings.sfxVolume;
    }
}
