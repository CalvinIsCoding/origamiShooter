using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Item/Air Dash")]
public class SoAirDash : ShopItemSO
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
