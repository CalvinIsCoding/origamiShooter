using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Short Range")]
public class SoShortRange : ShopItemSO
{
    public float percentOfCurrent;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.airBulletSize = playerInventory.airBulletSizeDefault;
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.BulletShrinkTime *= percentOfCurrent;
        
    }
}
