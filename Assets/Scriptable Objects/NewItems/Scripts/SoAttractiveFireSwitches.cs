using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Attractive Fire Switches")]
public class SoAttractiveFireSwitches : ShopItemSO
{
    
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        
    }
}
