using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Enemeis Die From Touch")]
public class SoEnemiesDieFromTouching : ShopItemSO
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
