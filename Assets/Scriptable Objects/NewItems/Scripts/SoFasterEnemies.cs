using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Faster Enemies")]
public class SoFasterEnemies : ShopItemSO
{
    public EnemyStats EnemyStats;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        
    }
}
