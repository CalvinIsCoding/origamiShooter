using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool hovering;
    public Animator ResumeButtonAnimator;
    public Animator SettingsButtonAnimator;
    public Animator QuitButtonAnimator;
    public Animator MusicButtonAnimator;
    public Animator SFXButtonAnimator;
    public Animator BackButtonAnimator;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public AudioSource GameplayMusic;
    public AudioSource PauseMusic;
    void OnEnable()
    {
        GameplayMusic.Stop();
        PauseMusic.Play();
        PauseMusic.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UnPause()
    {
        ResumeButtonAnimator.SetBool("mouse hovering", false);

       
        PauseMusic.Stop();
        GameplayMusic.Play();
        GameplayMusic.loop = true;

        hovering = false;
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
    }
    public void QuitButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SettingsButton()
    {
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void BackButton()
    {
        PauseMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    //Hovering Functions. These are separate functions for each button, and are used in teh 
    public void HoverOverResume()
    {
        ResumeButtonAnimator.SetBool("mouse hovering",true);
        hovering = true;
    }
    public void HoverOffResume()
    {
        ResumeButtonAnimator.SetBool("mouse hovering", false);
       
        hovering = false;
    }
    public void HoverOverSettings()
    {
        SettingsButtonAnimator.SetBool("mouse hovering", true);
        hovering = true;
    }
    public void HoverOffSettings()
    {
        SettingsButtonAnimator.SetBool("mouse hovering", false);

        hovering = false;
    }
    public void HoverOverQuit()
    {
        QuitButtonAnimator.SetBool("mouse hovering", true);
        hovering = true;
    }
    public void HoverOffQuit()
    {
        QuitButtonAnimator.SetBool("mouse hovering", false);

        hovering = false;
    }
    public void HoverOverBack()
    {
        BackButtonAnimator.SetBool("mouse hovering", true);
        hovering = true;
    }
    public void HoverOffBack()
    {
        BackButtonAnimator.SetBool("mouse hovering", false);

        hovering = false;
    }
    public void HoverOverSFX()
    {
        SFXButtonAnimator.SetBool("mouse hovering", true);
        hovering = true;
    }
    public void HoverOffSFX()
    {
        SFXButtonAnimator.SetBool("mouse hovering", false);

        hovering = false;
    }
    public void HoverOverMusic()
    {
        MusicButtonAnimator.SetBool("mouse hovering", true);
        hovering = true;
    }
    public void HoverOffMusic()
    {
        MusicButtonAnimator.SetBool("mouse hovering", false);

        hovering = false;
    }
}
