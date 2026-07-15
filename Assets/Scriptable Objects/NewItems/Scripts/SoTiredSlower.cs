using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/SoTiredSlower")]
public class SoTiredSlower : ShopItemSO
{
    public float overHeatMaxTimeIncrease;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.timeTillOverheat += overHeatMaxTimeIncrease;
    }
}
