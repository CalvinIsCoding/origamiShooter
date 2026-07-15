using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Broken burners")]
public class SoBrokenBurners : ShopItemSO
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
