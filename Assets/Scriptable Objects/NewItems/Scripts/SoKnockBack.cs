using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Knockback")]
public class SoKnockBack : ShopItemSO
{
    public float knockBackIncrement;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.knockBack += knockBackIncrement;
    }
}
