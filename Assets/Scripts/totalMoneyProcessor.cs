using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class totalMoneyProcessor : MonoBehaviour
{
    public TMP_Text totalMoneyText;
    public PlayerInventory playerInventory;
    public int moneyBeforeRoundMoneyIsAdded;
    public GameStatsScript gameStats;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator addToTotal(int moneyEarned)
    {
       
        moneyBeforeRoundMoneyIsAdded = playerInventory.coins;
        int i = moneyBeforeRoundMoneyIsAdded;
        for (i = moneyBeforeRoundMoneyIsAdded; i < moneyBeforeRoundMoneyIsAdded + moneyEarned + 1; i = i + 1)
        {
            totalMoneyText.SetText(i.ToString());
            yield return new WaitForSeconds(0.5f / moneyEarned);
        }
        playerInventory.coins = moneyBeforeRoundMoneyIsAdded + moneyEarned;
        gameStats.totalMoneyEarned = moneyBeforeRoundMoneyIsAdded + moneyEarned;

    }
}
