using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Smaller Air Stream")]
public class SoSmallerAirstream : ShopItemSO
{
    public float multiplier;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.airBulletSize = playerInventory.airBulletSize * multiplier;
    }
}
