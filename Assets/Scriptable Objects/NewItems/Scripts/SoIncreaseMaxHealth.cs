using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Max Health Increase")]
public class SoIncreaseMaxHealth : ShopItemSO
{
    public float maxHealthIncrement;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        playerInventory.maxLives = (int)(playerInventory.maxLives * maxHealthIncrement);
        playerInventory.lives += (int)(playerInventory.maxLives * (maxHealthIncrement - 1));
    }
}
