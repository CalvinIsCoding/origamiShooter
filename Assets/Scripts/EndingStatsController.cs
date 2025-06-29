using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndingStatsController : MonoBehaviour
{

    public TMP_Text moneyEarnedText;
    public TMP_Text enemiesKilledText;
    public TMP_Text wavesSurvivedText;
    public GameStatsScript gameStats;
  


    void Start()
    {
       

        moneyEarnedText.SetText(gameStats.totalMoneyEarned.ToString());
       
        enemiesKilledText.SetText(gameStats.totalEnemiesKilled.ToString());
        wavesSurvivedText.SetText(gameStats.wavesSurvived.ToString());
    }

   
}
