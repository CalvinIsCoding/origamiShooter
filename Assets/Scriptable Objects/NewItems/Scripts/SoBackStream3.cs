using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Item/Backstream3")]
public class SoBackStream3 : ShopItemSO
{
    public float backStreamModifier;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.backBulletSize += backStreamModifier;


    }
}
