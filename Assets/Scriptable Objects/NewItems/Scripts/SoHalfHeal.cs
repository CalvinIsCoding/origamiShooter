using UnityEngine;

[CreateAssetMenu(fileName = "shopMenu", menuName = "Scriptable Objects/Half Heal")]
public class SoHalfHeal : ShopItemSO
{
    
    public override void OnClearDowngrade()
    {
        base.OnClearDowngrade();
    }

    public override void OnPurchase()
    {
        
        playerInventory.lives += (playerInventory.maxLives / 2);
    }
}
