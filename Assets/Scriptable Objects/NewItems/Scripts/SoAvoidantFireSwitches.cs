using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/AvoidantFireSwitches")]
public class SoAvoidantFireSwitches : ShopItemSO
{
   
    public override void OnClearDowngrade()
    {
        //base.OnClearDowngrade();
        shop = FindAnyObjectByType<DoubleEdgedShop>();
        playerInventory.currentShopItems.Remove(this);
        shop.downgrades.Add(this);
        return;
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        //playerInventory.baseSpeed =+ baseSpeedIncrement;
        
    }
}
