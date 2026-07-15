using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Bigger Enemies")]
public class SoBiggerEnemies : ShopItemSO
{
    public float enemySizeIncreaseIncrement;
    public EnemyStats enemyStats;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
        playerInventory.currentShopItems.Remove(this);
    }

    public override void OnPurchase()
    {

        base.OnPurchase();
        enemyStats.enemyScaleModifier += enemySizeIncreaseIncrement;
        
    }
}
