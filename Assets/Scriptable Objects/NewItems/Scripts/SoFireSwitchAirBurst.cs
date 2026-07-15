using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/FireSwitch Air Burst")]
public class SoFireSwitchAirBurst : ShopItemSO
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
