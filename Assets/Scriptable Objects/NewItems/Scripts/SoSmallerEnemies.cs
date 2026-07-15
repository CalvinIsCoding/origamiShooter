using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Shop Items/Smaller Enemies")]
//[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/New loseBaseMovementSO")]
public class SoSmallerEnemies : ShopItemSO
{
    public EnemyStats enemyStats;
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        base.OnPurchase();
        enemyStats.enemyScaleModifier = enemyStats.enemyScaleModifier * 0.5f;
    }
}
