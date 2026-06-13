using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpDownShopManager : MonoBehaviour
{
    //public int coins;

    public PlayerInventory playerInventory;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO = new ShopItemSO[3];
   
    public GameObject[] shopButtonGameObject;
    public Button[] buttons;
    public Image[] images;

    public ShopButton downgradeButton;
    public ShopButton minorUpgradeButton;
    public ShopButton majorUpgradeButton;
    public List<ShopButton> shopButtons = new List<ShopButton>(3);

    public ShopItemSO[] minorUpgrades;
    public ShopItemSO[] majorUpgrades;
    public ShopItemSO[] downgrades;




    public GameObject ShopMenu;
    public TMP_Text totalMoney;
   

    void Start()
    {
        
        //playerInventory.coins = 0;
        //coinUI.text = "Coins: " + coins.ToString();
        coinUI.text = "Coins: " + playerInventory.coins.ToString();
        

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopButtonGameObject[i].SetActive(true);
            shopItemSO[i].numberPurchased = 0;

        }
        ChooseItems();
        LoadPanels();
        CheckPurchaseable();
    }

    private void OnEnable()
    {
      
        ChooseItems();
        LoadPanels();
        coinUI.text = "Coins: " + playerInventory.coins.ToString();
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
             shopButtons[i].TitleText.text = shopItemSO[i].title;
            //shopButton[i].ShopImage = images[i];
             shopButtons[i].PriceText.text = shopItemSO[i].cost.ToString();
            

        }
        


    }
    public void ChooseItems()
    {
        //there are only three buttons so I 'm just manually assinging them here
        shopItemSO[0] = downgrades[Random.Range(0, downgrades.Length)];
        shopItemSO[1] = minorUpgrades[Random.Range(0, minorUpgrades.Length)];
        shopItemSO[2] = majorUpgrades[Random.Range(0, majorUpgrades.Length)];
        
        
    }
    public void PurchaseItem(int btnNo)
    {
        if (playerInventory.coins >= shopItemSO[btnNo].cost)
        {
            playerInventory.coins = playerInventory.coins - shopItemSO[btnNo].cost;
            coinUI.text = "Coins: " + playerInventory.coins.ToString();
            CheckPurchaseable();
            shopItemSO[btnNo].numberPurchased++;
        }
        if (shopItemSO[btnNo].title == "Health")
        {
            Debug.Log("item type: " + shopItemSO[btnNo].title);
            playerInventory.lives++;
        }
        totalMoney.SetText(playerInventory.coins.ToString());
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
    public void ExitShop()
    {
        SetMultiplierModifiers();
        
        Time.timeScale = 1;
        ShopMenu.SetActive(false);
    }
    void SetMultiplierModifiers()
    {
        playerInventory.multiplierAdder = 0;
        playerInventory.multiplierMultiplier = 1;
        foreach (ShopItemSO shopitem in downgrades)
        {
            
            if (shopitem.numberPurchased >= 1)
            {
                playerInventory.multiplierAdder += shopitem.multiplierAdder;
                playerInventory.multiplierMultiplier += shopitem.multiplierMultiplier;
            }
            else
            {

            }
        }

    }


}
