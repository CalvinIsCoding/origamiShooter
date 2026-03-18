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

    public TMP_Text moneyEarnedTitle;
    public TMP_Text enemiesKilledTitle;
    public TMP_Text wavesSurvivedTitle;

    public TMP_Text[] endScreenTexts = new TMP_Text[3];
    public GameObject quitButton;
    public GameObject restartButton;


    public GameStatsScript gameStats;


   
    void Start()
    {
       

        moneyEarnedText.SetText(gameStats.totalMoneyEarned.ToString());
       
        enemiesKilledText.SetText(gameStats.totalEnemiesKilled.ToString());
        wavesSurvivedText.SetText(gameStats.wavesSurvived.ToString());
        for (int i = 0; i < endScreenTexts.Length; i++)
        {
            endScreenTexts[i].gameObject.SetActive(false);
            Debug.Log("i is" + i);
        }
        quitButton.SetActive(false);
        restartButton.SetActive(false);
    }
    private void OnEnable()
    {
        StartCoroutine(IntroduceTextSlowly());
    }

    public IEnumerator IntroduceTextSlowly()
    {
        for(int i = 0; i < endScreenTexts.Length; i++)
        {
            
            yield return new WaitForSeconds(1f);
            endScreenTexts[i].gameObject.SetActive(true);
        }

        quitButton.SetActive(true);
        restartButton.SetActive(true);
    }
}
