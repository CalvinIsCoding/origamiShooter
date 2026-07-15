using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



//[CreateAssetMenu(fileName = this.GetType().Name, menuName = "Scriptable Objects/New Shop Item")]
public class ShopItemSO : ScriptableObject
{
    
    public string title;
    public string description;
    public int cost;
    public int numberPurchased;
    public float modifier;
    public float multiplierAdder;
    public float multiplierMultiplier = 1f;
    public PlayerInventory playerInventory;
    public DoubleEdgedShop shop;
  
    public virtual void resetToDefaults()
    {
        numberPurchased = 0;
        //shop = FindAnyObjectByType<DoubleEdgedShop>();
    }
    public virtual void OnPurchase()
    {
        shop = FindAnyObjectByType<DoubleEdgedShop>();
        playerInventory.currentShopItems.Add(this);
        shop.upgrades.Remove(this);
        shop.downgrades.Remove(this);
        
        return;
    }
    public virtual void OnClearDowngrade()
    {
        //shop = FindAnyObjectByType<DoubleEdgedShop>();
        return;
    }

}
