using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Item/Backstream")]
public class SoBackStream : ShopItemSO
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
