using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Light Weight2")]
public class SoLightWeight2 : ShopItemSO
{
    public float massIncrement;
    public ShopItemSO lightweight3;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.mass = playerInventory.mass - massIncrement;
        shop.upgrades.Add(lightweight3);

    }
}
