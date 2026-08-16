using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Item/Backstream")]
public class SoBackStream : ShopItemSO
{
    public ShopItemSO backstream2;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        shop.upgrades.Add(backstream2);

    }
}
