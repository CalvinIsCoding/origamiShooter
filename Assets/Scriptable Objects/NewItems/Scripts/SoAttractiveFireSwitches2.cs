using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Attractive Fire Switches2")]
public class SoAttractiveFireSwitches2 : ShopItemSO
{
    public ShopItemSO fireSwitchMagnet3;
    
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        shop.upgrades.Add(fireSwitchMagnet3);
        playerInventory.fireSwitchMagnetStrength += modifier;
    }
}
