using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Item/All Vees")]
public class SoAllVs : ShopItemSO
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
