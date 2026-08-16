using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Max Health Increase3")]
public class SoIncreaseMaxHealth3 : ShopItemSO
{
    public float maxHealthIncrement;
    //public ShopItemSO maxhealth3;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.maxLives = (int)(playerInventory.maxLives * maxHealthIncrement);
        playerInventory.lives += (int)(playerInventory.maxLives * (maxHealthIncrement - 1));
        //shop.upgrades.Add(maxhealth3);
    }
}
