using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/SoLongRange")]
public class SoLongRange : ShopItemSO
{
    public float bulletLivingTimeModifier;
    public ShopItemSO longerRange2;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.BulletLivingTime += bulletLivingTimeModifier;
        playerInventory.BulletShrinkTime += bulletLivingTimeModifier;
        shop.upgrades.Add(longerRange2);

    }
}
