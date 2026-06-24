using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoubleEdgedShop : MonoBehaviour
{
    //public int coins;

    public PlayerInventory playerInventory;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemSO = new ShopItemSO[4];
   
    public GameObject[] shopButtonGameObject;
    public Button[] buttons;
    public Image[] images;

    public ShopButton downgradeButton;
    public ShopButton minorUpgradeButton;
    public ShopButton majorUpgradeButton;

    
    public List<ShopButton> shopButtons = new List<ShopButton>(4);

    public ShopItemSO[] upgrades;
    public ShopItemSO[] downgrades;




    public GameObject ShopMenu;
    public TMP_Text totalMoney;
    public bool shopExplainerSpawnedOnce;
    public GameObject shopExplainer;
    public DoubleEdgedButton[] doubleEdgedButton = new DoubleEdgedButton[2];
   

    void Start()
    {
        
        //playerInventory.downgradesPurchased = 0;
        //coinUI.text = "Coins: " + coins.ToString();
        coinUI.text = "Coins: " + playerInventory.downgradesPurchased.ToString();
        shopExplainerSpawnedOnce = false;

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopButtonGameObject[i].SetActive(true);
            shopItemSO[i].numberPurchased = 0;

        }
        ChooseItems();
        LoadPanels();
        //CheckPurchaseable();
    }

    private void OnEnable()
    {
      
        ChooseItems();
        LoadPanels();
        coinUI.text = "Coins: " + playerInventory.downgradesPurchased.ToString();
     // CheckPurchaseable();
        if (!shopExplainerSpawnedOnce)
        {

            EnableShopExplainer();
        }

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddCoins()
    {
        playerInventory.downgradesPurchased++;
        coinUI.text = "Coins: " + playerInventory.downgradesPurchased.ToString();
        CheckPurchaseable();
    }
    public void LoadPanels()
    {
        
        for (int i = 0; i < (shopItemSO.Length); i++)
        { 
             shopButtons[i].TitleText.text = shopItemSO[i].title;
            //shopButton[i].ShopImage = images[i];
             shopButtons[i].PriceText.text = (shopItemSO[i].cost * -1).ToString();

            shopButtons[i].shopItem = shopItemSO[i];

        }
        


    }
    public void ChooseItems()
    {
        //there are only three buttons so I 'm just manually assinging them here
        shopItemSO[0] = downgrades[Random.Range(0, downgrades.Length)];
        shopItemSO[1] = upgrades[Random.Range(0, upgrades.Length)];
        shopItemSO[2] = downgrades[Random.Range(0, downgrades.Length)];
        shopItemSO[3] = upgrades[Random.Range(0, upgrades.Length)];



        


    }
    public void PurchaseItem(int btnNo)
    {
        
            //shopItemSO[btnNo].numberPurchased++;

        foreach (ShopButton shopButton in doubleEdgedButton[btnNo].shopButtons) 
        {

            shopButton.shopItem.numberPurchased++;
        }

        /* 
        if (shopItemSO[btnNo].title == "Health")
        {
            Debug.Log("item type: " + shopItemSO[btnNo].title);
            playerInventory.lives++;
        }
        */
    }

    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (playerInventory.downgradesPurchased >= shopItemSO[i].cost)
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

    public void EnableShopExplainer()
    {
        shopExplainer.SetActive(true);
        shopExplainerSpawnedOnce = true;
    }
    public void ClearAllDowngrades()
    {
        foreach (var shopitem in downgrades)
        {
            shopitem.numberPurchased = 0;
        }
    }
    public void SelectOption()
    {

    }


}
