using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusOveralll : MonoBehaviour
{
    public AudioSource menuSound;
    public AudioClip forwardButtonSound;
    public AudioClip backButtonSound;
    public GameSettings gameSettings;
    
    
    public void ForwardSound()
    {   
        menuSound.volume = gameSettings.sfxVolume;
        menuSound.PlayOneShot(forwardButtonSound);
    }
    public void BackwardSound()
    {
        menuSound.volume = gameSettings.sfxVolume;
        menuSound.PlayOneShot(backButtonSound);
    }
}
