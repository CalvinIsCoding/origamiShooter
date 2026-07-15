using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/FireActivatorBoost")]
public class SoFireActivatorBoost : ShopItemSO
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
