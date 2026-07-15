using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/More Fire Switches")]
public class SoMoreFireSwitches : ShopItemSO
{
    
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.currentShopItems.Remove(this);
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.requiredActivators += 1;
        
    }
}
