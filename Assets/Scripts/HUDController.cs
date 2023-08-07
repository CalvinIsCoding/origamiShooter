using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
     public GameObject threeLives;
     public GameObject twoLives;
     public GameObject oneLife;

     public GameObject countDownBar;
     public playerController player;



   
    void Update()
    {
        if(player.lifeCount == 3)
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

        }
        
    }

   
}
