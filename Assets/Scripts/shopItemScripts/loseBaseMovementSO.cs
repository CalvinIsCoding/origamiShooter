using UnityEngine;
[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/New loseBaseMovementSO")]
public class loseBaseMovementSO : ShopItemSO
{
    
    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.loseWASDMovementEnabled = true;


    }
    public override void OnClearDowngrade()
    {
        playerInventory.loseWASDMovementEnabled = playerInventory.loseWASDMovementEnabledDefault;
        playerInventory.currentShopItems.Remove(this);
        shop.downgrades.Add(this);
        base.OnClearDowngrade();
    }
    
}
