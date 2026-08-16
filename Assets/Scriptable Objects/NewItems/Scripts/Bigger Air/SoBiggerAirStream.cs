using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/BiggerAirStream")]
public class SoBiggerAirStream : ShopItemSO
{
    public float airStreamSizeIncrement;
    public ShopItemSO biggerAirStream2;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.airBulletSize += airStreamSizeIncrement;
        shop.upgrades.Add(biggerAirStream2);
    }
}
