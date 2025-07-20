using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusOveralll : MonoBehaviour
{
    public AudioSource menuSound;
    public AudioClip forwardButtonSound;
    public AudioClip backButtonSound;
    
    public void ForwardSound()
    {
        menuSound.PlayOneShot(forwardButtonSound);
    }
    public void BackwardSound()
    {
        menuSound.PlayOneShot(backButtonSound);
    }
}
