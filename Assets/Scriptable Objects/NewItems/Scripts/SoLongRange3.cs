using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/SoLongRange3")]
public class SoLongRange3 : ShopItemSO
{
    public float bulletLivingTimeModifier;
   
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.BulletLivingTime += bulletLivingTimeModifier;
        playerInventory.BulletShrinkTime += bulletLivingTimeModifier;
        

    }
}
