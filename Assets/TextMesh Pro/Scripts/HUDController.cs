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


    public static float lives;
    public Text liveText;
    private void Start()
    {
        lives = player.lifeCount;
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

    }

   
}
