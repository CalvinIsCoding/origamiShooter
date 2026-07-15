using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Increase Walking Speed")]
public class IncreaseWalkingSpeed : ShopItemSO
{
    public float baseSpeedIncrement;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.baseSpeed = playerInventory.baseSpeed + baseSpeedIncrement;
    }
}
