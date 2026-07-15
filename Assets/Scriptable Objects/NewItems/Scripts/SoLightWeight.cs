using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Light Weight")]
public class SoLightWeight : ShopItemSO
{
    public float massIncrement;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.mass = playerInventory.mass - massIncrement;
    }
}
