using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/BiggerAirStream3")]
public class SoBiggerAirStream3 : ShopItemSO
{
    public float airStreamSizeIncrement;
    public ShopItemSO threeStream;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.airBulletSize += airStreamSizeIncrement;
        shop.upgrades.Add(threeStream);
    }
}
