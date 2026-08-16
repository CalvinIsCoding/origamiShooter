using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Knockback3")]
public class SoKnockBack3 : ShopItemSO
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
