using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
     public GameObject threeLives;
     public GameObject twoLives;
     public GameObject oneLife;

     public GameObject countDownBar;
     public PlayerInventory player;
    public GameObject pauseMenu;
    public GameObject shopMenu;
    public bool shopTouched;

    public static float lives;
    public Text liveText;
    public AudioSource GameMusic;
    public AudioClip gameplayMusic;
    public AudioClip pauseMusic;
    public AudioClip shopMusic;

    float playbackProgress;

    public Slider livesSlider;

    
    private void Start()
    {
        lives = player.lives;
        livesSlider.maxValue = player.lives;
        GameMusic.clip = gameplayMusic;
        GameMusic.Play();
      //  gameplayMusic.Play();
      //  gameplayMusic.loop = true;
    }

    void Update()
    {
        livesSlider.value = player.lives;
        lives = player.lives;
        liveText.text = lives.ToString() + " Lives";
        /* if(player.lifeCount == 3)
         {
             threeLives.SetActive(true);
             twoLives.SetActive(false);
             oneLife.SetActive(false);

         }
         else if (player.lifeCount == 2)
         {
             threeLives.SetActive(false);
             twoLives.SetActive(true);
             oneLife.SetActive(false);

         }

         else if (player.lifeCount == 1)
         {
             threeLives.SetActive(false);
             twoLives.SetActive(false);
             oneLife.SetActive(true);

         }*/
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
        if(shopTouched)
        {
            LaunchShop();
            shopTouched = false;
        }

        

        if (pauseMenu.activeInHierarchy == true)
        {
            GameMusic.clip = pauseMusic;
           
        }
        else if (shopMenu.activeInHierarchy == true)
        {
            GameMusic.clip = shopMusic;
            
        }
        else
        {
            
            GameMusic.clip = gameplayMusic;
            
        }
        //yikes this is ugly but it works
        if(GameMusic.isPlaying == false)
        {
            if(GameMusic.clip == gameplayMusic)
            {
                GameMusic.time = playbackProgress;
            }
            GameMusic.Play();
        }

       if (GameMusic.clip == gameplayMusic)
        {
            playbackProgress = GameMusic.time;
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        //gameplayMusic.Pause();
        //pauseMusic.Play();
        Time.timeScale = 0;
        
    }
    void LaunchShop()
    {

        
        
        shopMenu.SetActive(true);

        Time.timeScale = 0;

    }



}
