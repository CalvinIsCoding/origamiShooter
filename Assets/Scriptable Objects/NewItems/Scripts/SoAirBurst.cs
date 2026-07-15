using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/New AirBurst")]
public class SoAirBurst : ShopItemSO
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
