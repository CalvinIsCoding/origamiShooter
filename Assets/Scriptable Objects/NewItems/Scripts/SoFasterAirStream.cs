using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Faster Air Stream")]
public class SoFasterAirStream : ShopItemSO
{
    public float baseAirBulletSpeedIncrement;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.airBulletSpeed += baseAirBulletSpeedIncrement;
    }
    public override void resetToDefaults()
    {
        base.resetToDefaults();
        playerInventory.airBulletSpeed = playerInventory.airBulletSpeedDefault;
    }
}
