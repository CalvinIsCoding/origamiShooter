using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Attractive Fire Switches3")]
public class SoAttractiveFireSwitches3 : ShopItemSO
{
    
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.fireSwitchMagnetStrength += modifier;

    }
}
