using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/BiggerAirStream2")]
public class SoBiggerAirStream2 : ShopItemSO
{
    public float airStreamSizeIncrement;
    public ShopItemSO biggerAirStream3;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.airBulletSize += airStreamSizeIncrement;
        shop.upgrades.Add(biggerAirStream3);
    }
}
