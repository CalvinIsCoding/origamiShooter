using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Enemies MUST Die From Touching")]
public class SoEnemiesMustDieFromTouching : ShopItemSO
{
    
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.currentShopItems.Remove(this);
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        
    }
}
