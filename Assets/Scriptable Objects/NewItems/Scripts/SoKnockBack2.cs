using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Knockback2")]
public class SoKnockBack2 : ShopItemSO
{
    public float knockBackIncrement;
    public ShopItemSO knockback3;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.knockBack += knockBackIncrement;
        shop.upgrades.Add(knockback3);
    }
}
