using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/SoLongRange2")]
public class SoLongRange2 : ShopItemSO
{
    public float bulletLivingTimeModifier;
    public ShopItemSO longerRange3;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.BulletLivingTime += bulletLivingTimeModifier;
        playerInventory.BulletShrinkTime += bulletLivingTimeModifier;
        shop.upgrades.Add(longerRange3);

    }
}
