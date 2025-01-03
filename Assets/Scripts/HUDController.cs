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
     public PlayerController player;
    public GameObject pauseMenu;
    public GameObject shopMenu;
    public bool shopTouched;

    public static float lives;
    public Text liveText;
    public AudioSource gameplayMusic;
    public AudioSource pauseMusic;

    
    private void Start()
    {
        lives = player.lifeCount;
      //  gameplayMusic.Play();
      //  gameplayMusic.loop = true;
    }

    void Update()
    {
        lives = player.lifeCount;
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

        Time.timeScale = 0;
        
        shopMenu.SetActive(true);



    }



}
