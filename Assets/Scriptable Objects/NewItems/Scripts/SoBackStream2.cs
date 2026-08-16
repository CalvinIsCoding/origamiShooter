using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Item/Backstream2")]
public class SoBackStream2 : ShopItemSO
{
    public ShopItemSO backstream3;
    public float backStreamModifier;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        shop.upgrades.Add(backstream3);
        playerInventory.backBulletSize += backStreamModifier;

    }
}
