using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO;
    public ShopButton[] shopButton;
    public GameObject[] shopButtonGameObject;
    public Button[] buttons;

    void Start()
    {
        coinUI.text = "Coins: " + coins.ToString();

        for(int i = 0; i < shopItemSO.Length; i++)
        {
            shopButtonGameObject[i].SetActive(true);

        }
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins()
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }
    public void LoadPanels()
    {
        for (int i = 0; i < (shopItemSO.Length); i++)
        { 
             shopButton[i].TitleText.text = shopItemSO[i].title;
             shopButton[i].PriceText.text = shopItemSO[i].cost.ToString();
            

        }



    }
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemSO[btnNo].cost)
        {
            coins = coins - shopItemSO[btnNo].cost;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (coins >= shopItemSO[i].cost)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }

          }
    }
    

}
