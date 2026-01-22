using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class moneyEarnedThisRoundProcesser : MonoBehaviour
{
    public TMP_Text moneyEarnedText;
    public totalMoneyProcessor totalMoneyProcessor_;
    public Transform moneyEarnedTransform;
    public float maxScale;
    public float currentScale;
    public GameObject moneyEarnedObject;
    public Transform multiplierTransform;
    public Timers timers;
    void Start()
    {
        currentScale = 0;
        maxScale = 1;
        moneyEarnedObject.SetActive(false);
    }

   
    void Update()
    {
        moneyEarnedTransform.position = multiplierTransform.position;
    }
    public IEnumerator setMoneyEarnedThisRound(int moneyEarned)
    {
        int i;
        Debug.Log(moneyEarned);
        moneyEarnedObject.SetActive(true);
        for (i = 1; i < moneyEarned + 1; i = i +1)
        {
            moneyEarnedText.SetText(i.ToString());
           
            currentScale += (maxScale / moneyEarned);
            moneyEarnedTransform.localScale = Vector2.one * currentScale;
                  
            yield return new WaitForSeconds(timers.roundMoneyAddingTime/moneyEarned);
        }
        StartCoroutine(totalMoneyProcessor_.addToTotal(moneyEarned));
        StartCoroutine(ResetMoneySize());
       
       
    }
    public IEnumerator ResetMoneySize()
    {
        
        yield return new WaitForSeconds(timers.lullAfterFireModeEndsButWaveHasntBegun - timers.roundMoneyAddingTime - 0.5f); //for some reason the number hangs around for a split second longer than it should hence the 0.25f
        currentScale = 0;
        moneyEarnedTransform.localScale = Vector2.one * currentScale;
    }
}
