using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    //public int coins;

    public PlayerInventory playerInventory;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO;
    public ShopButton[] shopButton;
    public GameObject[] shopButtonGameObject;
    public Button[] buttons;

    
    
    void Start()
    {
        //playerInventory.coins = 0;
        //coinUI.text = "Coins: " + coins.ToString();
        coinUI.text = "Coins: " + playerInventory.coins.ToString();


        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopButtonGameObject[i].SetActive(true);

        }
        LoadPanels();
        CheckPurchaseable();
    }

    private void OnEnable()
    {
        CheckPurchaseable();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins()
    {
        playerInventory.coins++;
        coinUI.text = "Coins: " + playerInventory.coins.ToString();
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
        if (playerInventory.coins >= shopItemSO[btnNo].cost)
        {
            playerInventory.coins = playerInventory.coins - shopItemSO[btnNo].cost;
            coinUI.text = "Coins: " + playerInventory.coins.ToString();
            CheckPurchaseable();
        }
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (playerInventory.coins >= shopItemSO[i].cost)
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